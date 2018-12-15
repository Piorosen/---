namespace MapCreate
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_X = new System.Windows.Forms.TextBox();
            this.Text_Y = new System.Windows.Forms.TextBox();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.Btn_Map = new System.Windows.Forms.Button();
            this.Text_Alpha = new System.Windows.Forms.TextBox();
            this.Text_Green = new System.Windows.Forms.TextBox();
            this.Text_Red = new System.Windows.Forms.TextBox();
            this.Text_Blue = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y : ";
            // 
            // Text_X
            // 
            this.Text_X.Location = new System.Drawing.Point(56, 20);
            this.Text_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_X.Name = "Text_X";
            this.Text_X.Size = new System.Drawing.Size(168, 21);
            this.Text_X.TabIndex = 2;
            this.Text_X.Text = "0";
            // 
            // Text_Y
            // 
            this.Text_Y.Location = new System.Drawing.Point(274, 20);
            this.Text_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_Y.Name = "Text_Y";
            this.Text_Y.Size = new System.Drawing.Size(168, 21);
            this.Text_Y.TabIndex = 3;
            this.Text_Y.Text = "0";
            // 
            // Btn_Create
            // 
            this.Btn_Create.Location = new System.Drawing.Point(459, 10);
            this.Btn_Create.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(66, 37);
            this.Btn_Create.TabIndex = 4;
            this.Btn_Create.Text = "Create";
            this.Btn_Create.UseVisualStyleBackColor = true;
            this.Btn_Create.Click += new System.EventHandler(this.button1_Click);
            this.Btn_Create.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Btn_Create.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Btn_Create.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // Btn_Map
            // 
            this.Btn_Map.Location = new System.Drawing.Point(545, 10);
            this.Btn_Map.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Map.Name = "Btn_Map";
            this.Btn_Map.Size = new System.Drawing.Size(84, 37);
            this.Btn_Map.TabIndex = 5;
            this.Btn_Map.Text = "FileCreate";
            this.Btn_Map.UseVisualStyleBackColor = true;
            this.Btn_Map.Click += new System.EventHandler(this.Btn_Map_Click);
            // 
            // Text_Alpha
            // 
            this.Text_Alpha.Location = new System.Drawing.Point(663, 22);
            this.Text_Alpha.Name = "Text_Alpha";
            this.Text_Alpha.Size = new System.Drawing.Size(37, 21);
            this.Text_Alpha.TabIndex = 6;
            this.Text_Alpha.Text = "255";
            // 
            // Text_Green
            // 
            this.Text_Green.Location = new System.Drawing.Point(752, 22);
            this.Text_Green.Name = "Text_Green";
            this.Text_Green.Size = new System.Drawing.Size(31, 21);
            this.Text_Green.TabIndex = 7;
            this.Text_Green.Text = "255";
            // 
            // Text_Red
            // 
            this.Text_Red.Location = new System.Drawing.Point(706, 22);
            this.Text_Red.Name = "Text_Red";
            this.Text_Red.Size = new System.Drawing.Size(40, 21);
            this.Text_Red.TabIndex = 8;
            this.Text_Red.Text = "255";
            // 
            // Text_Blue
            // 
            this.Text_Blue.Location = new System.Drawing.Point(789, 22);
            this.Text_Blue.Name = "Text_Blue";
            this.Text_Blue.Size = new System.Drawing.Size(42, 21);
            this.Text_Blue.TabIndex = 9;
            this.Text_Blue.Text = "255";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(728, 369);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Move";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(728, 390);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 21);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 427);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Text_Blue);
            this.Controls.Add(this.Text_Red);
            this.Controls.Add(this.Text_Green);
            this.Controls.Add(this.Text_Alpha);
            this.Controls.Add(this.Btn_Map);
            this.Controls.Add(this.Btn_Create);
            this.Controls.Add(this.Text_X);
            this.Controls.Add(this.Text_Y);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "x";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_X;
        private System.Windows.Forms.TextBox Text_Y;
        private System.Windows.Forms.Button Btn_Create;
        private System.Windows.Forms.Button Btn_Map;
        private System.Windows.Forms.TextBox Text_Alpha;
        private System.Windows.Forms.TextBox Text_Green;
        private System.Windows.Forms.TextBox Text_Red;
        private System.Windows.Forms.TextBox Text_Blue;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

