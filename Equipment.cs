using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SmartFactory;

namespace SmartFactory
{
    enum Equipment
    {
        On,
        Off,
        Running,
        Error

    }

    interface iEquipment
    {
        string Name { get; }
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

        public event Action<iEquipment, Equipment> StateChanged;

        public Robot(string name)
        {
            Name = name;
            State = Equipment.Off;
        }

        public void Start()
        {

            State = Equipment.Running;

            StateChanged?.Invoke(this, State);
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
        Dictionary<string, iEquipment> machine = new Dictionary<string, iEquipment>();

        public event Action<iEquipment, Equipment> StateChanged;

        public void Addmachine(iEquipment item)
        {
            if (machine.ContainsKey(item.Name))
            {              
                machine[item.Name].StateChanged -= OnMachineEvent;
                machine.Remove(item.Name);
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

        public void OnMachineEvent(iEquipment machine, Equipment state)
        {
            StateChanged?.Invoke(machine, state);
        }

    }
}
