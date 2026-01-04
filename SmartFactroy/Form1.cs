using Microsoft.VisualBasic.Logging;
using SmartFactory;

namespace SmartFactory
{
    public partial class Form1 : Form
    {
        FactoryControll _controller = new FactoryControll();
        public Form1()
        {
            InitializeComponent();
        }
        void Log(iEquipment machine, Equipment state)
        {
            string msg = $"{DateTime.Now:HH:mm:ss} | {machine.Name} : {state}";
            lst.Items.Add(msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _controller.StateChanged += Log;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstMachines.Items.Contains("Arm_Unit_01") && lstMachines.Items.Contains("Welder_Unit_02"))
            {
                MessageBox.Show("이미 로봇들이 일하고 있어.");
                return;
            }

            Robot r1 = new Robot("Arm_Unit_01");
            Robot r2 = new Robot("Welder_Unit_02");

            _controller.Addmachine(r1);
            _controller.Addmachine(r2);

            if (!lstMachines.Items.Contains(r1.Name)) lstMachines.Items.Add(r1.Name);
            if (!lstMachines.Items.Contains(r2.Name)) lstMachines.Items.Add(r2.Name);

            r1.Start();
            r2.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string targetName = txt.Text;
            if (string.IsNullOrWhiteSpace(targetName)) return;

            // 2. 컨트롤러에서 기계 찾기
            var item = _controller.GetMachine(targetName);

            // 3. 있으면 정지, 없으면 경고
            if (item != null)
            {
                item.Stop(); // 장비 정지!
            }
            else
            {
                MessageBox.Show("장비를 찾을수 없습니다?");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string targetName = txt.Text;
            if (string.IsNullOrWhiteSpace(targetName)) return;
            var item = _controller.GetMachine(targetName);

            if (item != null)
            {
                item.Error(); // 강제 고장 발생!
            }
            else
            {
                MessageBox.Show("고장 낼 장비를 못 찾겠어.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string nameToRemove = txt.Text;

            if (string.IsNullOrWhiteSpace(nameToRemove)) return;

            _controller.RemoveMachine(nameToRemove);

            // [중요] 목록에서도 쓱 지워준다
            lstMachines.Items.Remove(nameToRemove);

            lst.Items.Add($"[제거됨] {nameToRemove}");
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 아무것도 선택 안 했으면 무시
            if (lstMachines.SelectedItem == null) return;

            // 선택한 놈 글자를 텍스트박스에 쏙 넣음
            txt.Text = lstMachines.SelectedItem.ToString();
        }
    }
}
