namespace Aoi_Macro
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Add_Button = new System.Windows.Forms.Button();
            this.Run_Button = new System.Windows.Forms.Button();
            this.Record_List = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Mouse_Thread = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(12, 12);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(65, 36);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "마우스";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Mouse);
            // 
            // Run_Button
            // 
            this.Run_Button.Location = new System.Drawing.Point(154, 12);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(138, 36);
            this.Run_Button.TabIndex = 3;
            this.Run_Button.Text = "실행";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run);
            // 
            // Record_List
            // 
            this.Record_List.FormattingEnabled = true;
            this.Record_List.ItemHeight = 12;
            this.Record_List.Items.AddRange(new object[] {
            "( 프로그래밍 : 차주형 )"});
            this.Record_List.Location = new System.Drawing.Point(12, 56);
            this.Record_List.Name = "Record_List";
            this.Record_List.Size = new System.Drawing.Size(280, 244);
            this.Record_List.TabIndex = 0;
            this.Record_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Record_List_MouseClick);
            this.Record_List.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Record_List_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "키보드";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Keyboard);
            // 
            // Mouse_Thread
            // 
            this.Mouse_Thread.Interval = 1;
            this.Mouse_Thread.Tick += new System.EventHandler(this.Mouse_Thread_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "삭제",
            "딜레이 주기",
            "------------",
            "취소"});
            this.listBox1.Location = new System.Drawing.Point(154, 194);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(73, 52);
            this.listBox1.TabIndex = 4;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 312);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Record_List);
            this.Controls.Add(this.Run_Button);
            this.Controls.Add(this.Add_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "매크로 프로그램";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.ListBox Record_List;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Mouse_Thread;
        private System.Windows.Forms.ListBox listBox1;

    }
}

