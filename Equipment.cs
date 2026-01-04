using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SmartFactory;

namespace SmartFactory
{
    enum Equipment //정수를 사용하지 않고 enum을 사용하여 더 안정적임
    {
        On,
        Off,
        Running,
        Error

    }

    interface iEquipment //인터페이스를 사용하여 기존의 제어 로직을 변경하지 않고도 시스템 확장이 가능함
    {
        string Name { get; } //보안을 위해 get만 사용함, 무결성을 위해 get만 사용
        Equipment State { get; }

        event Action<iEquipment, Equipment> StateChanged;

        void Start();
        void Stop();
        void Error();


    }

    class Robot : iEquipment
    {
        public string Name { get; private set; }
        public Equipment State { get; private set; }

        public event Action<iEquipment, Equipment> StateChanged;   // 상태가 바뀔 때 알림을 보내는 이벤트
                                                                    // Action<iEquipment, Equipment> : 이벤트 구독자에게 자신(this)과 현재 상태(State) 전달
        public Robot(string name)
        {
            Name = name;
            State = Equipment.Off;
        }

        public void Start()
        {

            State = Equipment.Running;

            StateChanged?.Invoke(this, State);   // 2. Invoke 이벤트를 통해 구독자(UI 등)에게 내 상태가 변했음을 알림
        }

        public void Stop()
        {
            State = Equipment.Off;
            StateChanged?.Invoke(this, State);
        }

        public void Error()
        {
            State = Equipment.Error;
            StateChanged?.Invoke(this, State);
        }
    }

    class FactoryControll
    {
        Dictionary<string, iEquipment> machine = new Dictionary<string, iEquipment>(); // 리스트를 처음부터 끝까지 뒤지는 노가다(foreach) 대신 딕셔너리 사용

        public event Action<iEquipment, Equipment> StateChanged;

        public void Addmachine(iEquipment item)
        {
            if (machine.ContainsKey(item.Name)) // 같은 장비의 이름이 있는지 중복 체크를 한다.
            {              
                machine[item.Name].StateChanged -= OnMachineEvent; // 이벤트 구독 해제
                machine.Remove(item.Name); // 기존 장비 제거
            }

            machine.Add(item.Name, item);

            item.StateChanged += OnMachineEvent;
        }

        public void RemoveMachine(string name)
        {
           
            if (!machine.ContainsKey(name))
            {
                return;
            }

            iEquipment item = machine[name]; //이름을 키에 넣어서 찾음
            item.StateChanged -= OnMachineEvent;

           
            machine.Remove(name);
        }

        public iEquipment GetMachine(string name)
        {
            if (machine.ContainsKey(name))
            {
                return machine[name];
            }
            return null;
        }

        public void OnMachineEvent(iEquipment machine, Equipment state) // Robot가 보내온 신호를 받아서 UI으로 토스함
        {
            StateChanged?.Invoke(machine, state);
        }

    }
}

