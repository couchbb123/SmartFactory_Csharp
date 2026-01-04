namespace SmartFactory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblState = new Label();
            btnStart = new Button();
            btnStop = new Button();
            btnTest = new Button();
            lst = new ListBox();
            btnRemove = new Button();
            txt = new TextBox();
            lstMachines = new ListBox();
            SuspendLayout();
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.BorderStyle = BorderStyle.FixedSingle;
            lblState.Font = new Font("맑은 고딕", 20F);
            lblState.Location = new Point(341, 62);
            lblState.Name = "lblState";
            lblState.Size = new Size(199, 39);
            lblState.TabIndex = 0;
            lblState.Text = "시스템 대기 중";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(256, 156);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "전체 가동";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(256, 205);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "지정";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(256, 251);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(75, 23);
            btnTest.TabIndex = 3;
            btnTest.Text = "에러 발생";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // lst
            // 
            lst.FormattingEnabled = true;
            lst.ItemHeight = 15;
            lst.Location = new Point(366, 156);
            lst.Name = "lst";
            lst.Size = new Size(222, 154);
            lst.TabIndex = 4;
            lst.SelectedIndexChanged += Form1_Load;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(256, 293);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "장비 제거";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // txt
            // 
            txt.Location = new Point(417, 341);
            txt.Name = "txt";
            txt.Size = new Size(100, 23);
            txt.TabIndex = 6;
            // 
            // lstMachines
            // 
            lstMachines.FormattingEnabled = true;
            lstMachines.ItemHeight = 15;
            lstMachines.Location = new Point(621, 156);
            lstMachines.Name = "lstMachines";
            lstMachines.Size = new Size(167, 154);
            lstMachines.TabIndex = 7;
            lstMachines.SelectedIndexChanged += lstMachines_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstMachines);
            Controls.Add(txt);
            Controls.Add(btnRemove);
            Controls.Add(lst);
            Controls.Add(btnTest);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblState);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblState;
        private Button btnStart;
        private Button btnStop;
        private Button btnTest;
        private ListBox lst;
        private Button btnRemove;
        private TextBox txt;
        private ListBox lstMachines;
    }
}
