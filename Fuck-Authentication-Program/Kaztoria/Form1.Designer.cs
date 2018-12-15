namespace Kaztoria
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
            this.ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PD = new System.Windows.Forms.TextBox();
            this.check = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(12, 28);
            this.ID.Name = "ID";
            this.ID.PasswordChar = '●';
            this.ID.Size = new System.Drawing.Size(364, 21);
            this.ID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "아 이 디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "비 밀 번 호";
            // 
            // PD
            // 
            this.PD.Location = new System.Drawing.Point(15, 72);
            this.PD.Name = "PD";
            this.PD.PasswordChar = '●';
            this.PD.Size = new System.Drawing.Size(361, 21);
            this.PD.TabIndex = 2;
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(17, 110);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(110, 57);
            this.check.TabIndex = 3;
            this.check.Text = "인 증";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.Check_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(153, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "제1 약관";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBox1_Click);
            this.checkBox1.MouseLeave += new System.EventHandler(this.checkBox_leave);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(153, 132);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(70, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "제2 약관";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBox2_Click);
            this.checkBox2.MouseLeave += new System.EventHandler(this.checkBox_leave);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(153, 154);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(70, 16);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "제3 약관";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBox3_Click);
            this.checkBox3.MouseLeave += new System.EventHandler(this.checkBox_leave);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(245, 110);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(70, 16);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "제4 약관";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBox4_Click);
            this.checkBox4.MouseLeave += new System.EventHandler(this.checkBox_leave);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(245, 132);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(70, 16);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "제5 약관";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBox5_Click);
            this.checkBox5.MouseLeave += new System.EventHandler(this.checkBox_leave);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(245, 154);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(70, 16);
            this.checkBox6.TabIndex = 9;
            this.checkBox6.Text = "제6 약관";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBox6_Click);
            this.checkBox6.MouseLeave += new System.EventHandler(this.checkBox_leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 187);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.check);
            this.Controls.Add(this.PD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID);
            this.Name = "Form1";
            this.Text = "인증 프로그램";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PD;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
    }
}

