namespace N사_오토_프로그램
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CheckBox_HidePassword = new MaterialSkin.Controls.MaterialCheckBox();
            this.Pic_Hide = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Label_Login_Option = new MaterialSkin.Controls.MaterialLabel();
            this.Button_Login = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Text_PW = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Text_ID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Label_PW = new MaterialSkin.Controls.MaterialLabel();
            this.Label_ID = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Text_Delay = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Label = new MaterialSkin.Controls.MaterialLabel();
            this.Button_SettingSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Button_Update = new MaterialSkin.Controls.MaterialRaisedButton();
            this.CheckBox_ScreenMode = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckBox_AutoUpdate = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckBox_AutoLogin = new MaterialSkin.Controls.MaterialCheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Check_Delete = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Text_CafeName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Text_Tag = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Text_Title = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Text_CafeID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Text_MenuID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Text_Content = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Button_Search = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Button_Del = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Button_Add = new MaterialSkin.Controls.MaterialRaisedButton();
            this.List_List = new System.Windows.Forms.ListBox();
            this.Button_Option = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Button_Stop = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Button_Start = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton4 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton5 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = null;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(500, 23);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 93);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(479, 206);
            this.materialTabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.CheckBox_HidePassword);
            this.tabPage1.Controls.Add(this.Pic_Hide);
            this.tabPage1.Controls.Add(this.Label_Login_Option);
            this.tabPage1.Controls.Add(this.Button_Login);
            this.tabPage1.Controls.Add(this.Text_PW);
            this.tabPage1.Controls.Add(this.Text_ID);
            this.tabPage1.Controls.Add(this.Label_PW);
            this.tabPage1.Controls.Add(this.Label_ID);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(471, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            // 
            // CheckBox_HidePassword
            // 
            this.CheckBox_HidePassword.AutoSize = true;
            this.CheckBox_HidePassword.Depth = 0;
            this.CheckBox_HidePassword.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBox_HidePassword.Location = new System.Drawing.Point(6, 73);
            this.CheckBox_HidePassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_HidePassword.Name = "CheckBox_HidePassword";
            this.CheckBox_HidePassword.Size = new System.Drawing.Size(121, 22);
            this.CheckBox_HidePassword.TabIndex = 7;
            this.CheckBox_HidePassword.Text = "Hide Password";
            this.CheckBox_HidePassword.UseVisualStyleBackColor = true;
            this.CheckBox_HidePassword.CheckedChanged += new System.EventHandler(this.CheckBox_HidePassword_CheckedChanged);
            // 
            // Pic_Hide
            // 
            this.Pic_Hide.Depth = 0;
            this.Pic_Hide.Location = new System.Drawing.Point(49, 44);
            this.Pic_Hide.MouseState = MaterialSkin.MouseState.HOVER;
            this.Pic_Hide.Name = "Pic_Hide";
            this.Pic_Hide.Primary = true;
            this.Pic_Hide.Size = new System.Drawing.Size(281, 20);
            this.Pic_Hide.TabIndex = 6;
            this.Pic_Hide.UseVisualStyleBackColor = true;
            this.Pic_Hide.Visible = false;
            this.Pic_Hide.Click += new System.EventHandler(this.Pic_Hide_Click);
            // 
            // Label_Login_Option
            // 
            this.Label_Login_Option.AutoSize = true;
            this.Label_Login_Option.Depth = 0;
            this.Label_Login_Option.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_Login_Option.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_Login_Option.Location = new System.Drawing.Point(6, 98);
            this.Label_Login_Option.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Login_Option.Name = "Label_Login_Option";
            this.Label_Login_Option.Size = new System.Drawing.Size(79, 19);
            this.Label_Login_Option.TabIndex = 5;
            this.Label_Login_Option.Text = "로그인 대기중";
            // 
            // Button_Login
            // 
            this.Button_Login.Depth = 0;
            this.Button_Login.Location = new System.Drawing.Point(339, 11);
            this.Button_Login.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Primary = true;
            this.Button_Login.Size = new System.Drawing.Size(123, 68);
            this.Button_Login.TabIndex = 4;
            this.Button_Login.Text = "LOGIN";
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // Text_PW
            // 
            this.Text_PW.Depth = 0;
            this.Text_PW.Hint = "비밀번호를 입력해 주세요.";
            this.Text_PW.Location = new System.Drawing.Point(49, 44);
            this.Text_PW.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_PW.Name = "Text_PW";
            this.Text_PW.Size = new System.Drawing.Size(281, 23);
            this.Text_PW.TabIndex = 1;
            // 
            // Text_ID
            // 
            this.Text_ID.Depth = 0;
            this.Text_ID.Hint = "아이디를 입력해 주세요.";
            this.Text_ID.Location = new System.Drawing.Point(49, 16);
            this.Text_ID.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_ID.Name = "Text_ID";
            this.Text_ID.Size = new System.Drawing.Size(281, 23);
            this.Text_ID.TabIndex = 0;
            this.Text_ID.Click += new System.EventHandler(this.Text_ID_Click);
            // 
            // Label_PW
            // 
            this.Label_PW.AutoSize = true;
            this.Label_PW.Depth = 0;
            this.Label_PW.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_PW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_PW.Location = new System.Drawing.Point(7, 45);
            this.Label_PW.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_PW.Name = "Label_PW";
            this.Label_PW.Size = new System.Drawing.Size(39, 19);
            this.Label_PW.TabIndex = 1;
            this.Label_PW.Text = "PW :";
            // 
            // Label_ID
            // 
            this.Label_ID.AutoSize = true;
            this.Label_ID.Depth = 0;
            this.Label_ID.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_ID.Location = new System.Drawing.Point(7, 17);
            this.Label_ID.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_ID.Name = "Label_ID";
            this.Label_ID.Size = new System.Drawing.Size(39, 19);
            this.Label_ID.TabIndex = 0;
            this.Label_ID.Text = "ID   :";
            this.Label_ID.Click += new System.EventHandler(this.Label_ID_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.Text_Delay);
            this.tabPage2.Controls.Add(this.Label);
            this.tabPage2.Controls.Add(this.Button_SettingSave);
            this.tabPage2.Controls.Add(this.Button_Update);
            this.tabPage2.Controls.Add(this.CheckBox_ScreenMode);
            this.tabPage2.Controls.Add(this.CheckBox_AutoUpdate);
            this.tabPage2.Controls.Add(this.CheckBox_AutoLogin);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(471, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            // 
            // Text_Delay
            // 
            this.Text_Delay.Depth = 0;
            this.Text_Delay.Hint = "기본설정 : 1  (단위 : 60분)";
            this.Text_Delay.Location = new System.Drawing.Point(72, 68);
            this.Text_Delay.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_Delay.Name = "Text_Delay";
            this.Text_Delay.Size = new System.Drawing.Size(169, 23);
            this.Text_Delay.TabIndex = 6;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Depth = 0;
            this.Label.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label.Location = new System.Drawing.Point(10, 68);
            this.Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(65, 19);
            this.Label.TabIndex = 5;
            this.Label.Text = "대기시간 : ";
            // 
            // Button_SettingSave
            // 
            this.Button_SettingSave.Depth = 0;
            this.Button_SettingSave.Location = new System.Drawing.Point(348, 165);
            this.Button_SettingSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_SettingSave.Name = "Button_SettingSave";
            this.Button_SettingSave.Primary = true;
            this.Button_SettingSave.Size = new System.Drawing.Size(111, 33);
            this.Button_SettingSave.TabIndex = 4;
            this.Button_SettingSave.Text = "Option Save";
            this.Button_SettingSave.UseVisualStyleBackColor = true;
            this.Button_SettingSave.Click += new System.EventHandler(this.Button_SettingSave_Click);
            // 
            // Button_Update
            // 
            this.Button_Update.Depth = 0;
            this.Button_Update.Location = new System.Drawing.Point(384, 14);
            this.Button_Update.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Primary = true;
            this.Button_Update.Size = new System.Drawing.Size(75, 23);
            this.Button_Update.TabIndex = 3;
            this.Button_Update.Text = "Update";
            this.Button_Update.UseVisualStyleBackColor = true;
            this.Button_Update.Click += new System.EventHandler(this.Button_Update_Click);
            // 
            // CheckBox_ScreenMode
            // 
            this.CheckBox_ScreenMode.AutoSize = true;
            this.CheckBox_ScreenMode.Depth = 0;
            this.CheckBox_ScreenMode.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBox_ScreenMode.Location = new System.Drawing.Point(11, 43);
            this.CheckBox_ScreenMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_ScreenMode.Name = "CheckBox_ScreenMode";
            this.CheckBox_ScreenMode.Size = new System.Drawing.Size(107, 22);
            this.CheckBox_ScreenMode.TabIndex = 2;
            this.CheckBox_ScreenMode.Text = "Screen Mode";
            this.CheckBox_ScreenMode.UseVisualStyleBackColor = true;
            this.CheckBox_ScreenMode.CheckedChanged += new System.EventHandler(this.CheckBox_ScreenMode_CheckedChanged);
            // 
            // CheckBox_AutoUpdate
            // 
            this.CheckBox_AutoUpdate.AutoSize = true;
            this.CheckBox_AutoUpdate.Depth = 0;
            this.CheckBox_AutoUpdate.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBox_AutoUpdate.Location = new System.Drawing.Point(14, 143);
            this.CheckBox_AutoUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_AutoUpdate.Name = "CheckBox_AutoUpdate";
            this.CheckBox_AutoUpdate.Size = new System.Drawing.Size(105, 22);
            this.CheckBox_AutoUpdate.TabIndex = 1;
            this.CheckBox_AutoUpdate.Text = "Auto Update";
            this.CheckBox_AutoUpdate.UseVisualStyleBackColor = true;
            this.CheckBox_AutoUpdate.Visible = false;
            this.CheckBox_AutoUpdate.CheckedChanged += new System.EventHandler(this.CheckBox_AutoUpdate_CheckedChanged);
            // 
            // CheckBox_AutoLogin
            // 
            this.CheckBox_AutoLogin.AutoSize = true;
            this.CheckBox_AutoLogin.Depth = 0;
            this.CheckBox_AutoLogin.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBox_AutoLogin.Location = new System.Drawing.Point(11, 15);
            this.CheckBox_AutoLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBox_AutoLogin.Name = "CheckBox_AutoLogin";
            this.CheckBox_AutoLogin.Size = new System.Drawing.Size(95, 22);
            this.CheckBox_AutoLogin.TabIndex = 0;
            this.CheckBox_AutoLogin.Text = "Auto Login";
            this.CheckBox_AutoLogin.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.Button_Option);
            this.tabPage3.Controls.Add(this.Button_Stop);
            this.tabPage3.Controls.Add(this.Button_Start);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(471, 180);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Run";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Check_Delete);
            this.panel1.Controls.Add(this.materialRaisedButton2);
            this.panel1.Controls.Add(this.Text_CafeName);
            this.panel1.Controls.Add(this.Text_Tag);
            this.panel1.Controls.Add(this.Text_Title);
            this.panel1.Controls.Add(this.Text_CafeID);
            this.panel1.Controls.Add(this.Text_MenuID);
            this.panel1.Controls.Add(this.Text_Content);
            this.panel1.Controls.Add(this.Button_Search);
            this.panel1.Controls.Add(this.Button_Del);
            this.panel1.Controls.Add(this.Button_Add);
            this.panel1.Controls.Add(this.List_List);
            this.panel1.Location = new System.Drawing.Point(68, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 192);
            this.panel1.TabIndex = 5;
            // 
            // Check_Delete
            // 
            this.Check_Delete.AutoSize = true;
            this.Check_Delete.Depth = 0;
            this.Check_Delete.Font = new System.Drawing.Font("Roboto", 10F);
            this.Check_Delete.Location = new System.Drawing.Point(121, 155);
            this.Check_Delete.MouseState = MaterialSkin.MouseState.HOVER;
            this.Check_Delete.Name = "Check_Delete";
            this.Check_Delete.Size = new System.Drawing.Size(98, 22);
            this.Check_Delete.TabIndex = 23;
            this.Check_Delete.Text = "Auto Delete";
            this.Check_Delete.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.BackColor = System.Drawing.SystemColors.Control;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(321, 33);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(65, 21);
            this.materialRaisedButton2.TabIndex = 22;
            this.materialRaisedButton2.Text = "Serach";
            this.materialRaisedButton2.UseVisualStyleBackColor = false;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // Text_CafeName
            // 
            this.Text_CafeName.BackColor = System.Drawing.SystemColors.Control;
            this.Text_CafeName.Depth = 0;
            this.Text_CafeName.Hint = "Cafe Name";
            this.Text_CafeName.Location = new System.Drawing.Point(123, 96);
            this.Text_CafeName.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_CafeName.Name = "Text_CafeName";
            this.Text_CafeName.Size = new System.Drawing.Size(146, 23);
            this.Text_CafeName.TabIndex = 20;
            // 
            // Text_Tag
            // 
            this.Text_Tag.BackColor = System.Drawing.SystemColors.Control;
            this.Text_Tag.Depth = 0;
            this.Text_Tag.Hint = "Tag";
            this.Text_Tag.Location = new System.Drawing.Point(123, 5);
            this.Text_Tag.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_Tag.Name = "Text_Tag";
            this.Text_Tag.Size = new System.Drawing.Size(263, 23);
            this.Text_Tag.TabIndex = 19;
            // 
            // Text_Title
            // 
            this.Text_Title.BackColor = System.Drawing.SystemColors.Control;
            this.Text_Title.Depth = 0;
            this.Text_Title.Hint = "Title";
            this.Text_Title.Location = new System.Drawing.Point(123, 34);
            this.Text_Title.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_Title.Name = "Text_Title";
            this.Text_Title.Size = new System.Drawing.Size(192, 23);
            this.Text_Title.TabIndex = 18;
            // 
            // Text_CafeID
            // 
            this.Text_CafeID.BackColor = System.Drawing.SystemColors.Control;
            this.Text_CafeID.Depth = 0;
            this.Text_CafeID.Hint = "Cafe ID";
            this.Text_CafeID.Location = new System.Drawing.Point(275, 96);
            this.Text_CafeID.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_CafeID.Name = "Text_CafeID";
            this.Text_CafeID.Size = new System.Drawing.Size(111, 23);
            this.Text_CafeID.TabIndex = 17;
            // 
            // Text_MenuID
            // 
            this.Text_MenuID.BackColor = System.Drawing.SystemColors.Control;
            this.Text_MenuID.Depth = 0;
            this.Text_MenuID.Hint = "Menu ID";
            this.Text_MenuID.Location = new System.Drawing.Point(123, 128);
            this.Text_MenuID.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_MenuID.Name = "Text_MenuID";
            this.Text_MenuID.Size = new System.Drawing.Size(263, 23);
            this.Text_MenuID.TabIndex = 16;
            // 
            // Text_Content
            // 
            this.Text_Content.BackColor = System.Drawing.SystemColors.Control;
            this.Text_Content.Depth = 0;
            this.Text_Content.Hint = "Cotent File";
            this.Text_Content.Location = new System.Drawing.Point(123, 63);
            this.Text_Content.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_Content.Name = "Text_Content";
            this.Text_Content.Size = new System.Drawing.Size(192, 23);
            this.Text_Content.TabIndex = 13;
            // 
            // Button_Search
            // 
            this.Button_Search.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Search.Depth = 0;
            this.Button_Search.Location = new System.Drawing.Point(321, 63);
            this.Button_Search.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Primary = true;
            this.Button_Search.Size = new System.Drawing.Size(65, 21);
            this.Button_Search.TabIndex = 14;
            this.Button_Search.Text = "Serach";
            this.Button_Search.UseVisualStyleBackColor = false;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // Button_Del
            // 
            this.Button_Del.Depth = 0;
            this.Button_Del.Location = new System.Drawing.Point(63, 166);
            this.Button_Del.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Del.Name = "Button_Del";
            this.Button_Del.Primary = true;
            this.Button_Del.Size = new System.Drawing.Size(54, 23);
            this.Button_Del.TabIndex = 4;
            this.Button_Del.Text = "Del";
            this.Button_Del.UseVisualStyleBackColor = true;
            this.Button_Del.Click += new System.EventHandler(this.Button_Del_Click);
            // 
            // Button_Add
            // 
            this.Button_Add.Depth = 0;
            this.Button_Add.Location = new System.Drawing.Point(3, 166);
            this.Button_Add.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Primary = true;
            this.Button_Add.Size = new System.Drawing.Size(54, 23);
            this.Button_Add.TabIndex = 1;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // List_List
            // 
            this.List_List.FormattingEnabled = true;
            this.List_List.ItemHeight = 12;
            this.List_List.Location = new System.Drawing.Point(3, 3);
            this.List_List.Name = "List_List";
            this.List_List.Size = new System.Drawing.Size(114, 160);
            this.List_List.TabIndex = 0;
            this.List_List.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Button_Option
            // 
            this.Button_Option.Depth = 0;
            this.Button_Option.Location = new System.Drawing.Point(3, 134);
            this.Button_Option.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Option.Name = "Button_Option";
            this.Button_Option.Primary = true;
            this.Button_Option.Size = new System.Drawing.Size(56, 39);
            this.Button_Option.TabIndex = 4;
            this.Button_Option.Text = "Run Option";
            this.Button_Option.UseVisualStyleBackColor = true;
            this.Button_Option.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // Button_Stop
            // 
            this.Button_Stop.Depth = 0;
            this.Button_Stop.Location = new System.Drawing.Point(3, 76);
            this.Button_Stop.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Primary = true;
            this.Button_Stop.Size = new System.Drawing.Size(56, 39);
            this.Button_Stop.TabIndex = 1;
            this.Button_Stop.Text = "Auto Stop";
            this.Button_Stop.UseVisualStyleBackColor = true;
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Button_Start
            // 
            this.Button_Start.Depth = 0;
            this.Button_Start.Location = new System.Drawing.Point(3, 18);
            this.Button_Start.MouseState = MaterialSkin.MouseState.HOVER;
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Primary = true;
            this.Button_Start.Size = new System.Drawing.Size(59, 39);
            this.Button_Start.TabIndex = 0;
            this.Button_Start.Text = "Auto Start";
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Controls.Add(this.materialRaisedButton4);
            this.tabPage4.Controls.Add(this.materialRaisedButton3);
            this.tabPage4.Controls.Add(this.materialRaisedButton1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(471, 180);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Developer";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.materialLabel12);
            this.panel4.Controls.Add(this.materialLabel11);
            this.panel4.Location = new System.Drawing.Point(163, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(305, 174);
            this.panel4.TabIndex = 5;
            this.panel4.Visible = false;
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(4, 30);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(187, 19);
            this.materialLabel12.TabIndex = 2;
            this.materialLabel12.Text = "ControlMove : Self Making";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(4, 10);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(152, 19);
            this.materialLabel11.TabIndex = 1;
            this.materialLabel11.Text = "AES256 : Self Making";
            // 
            // materialRaisedButton4
            // 
            this.materialRaisedButton4.Depth = 0;
            this.materialRaisedButton4.Location = new System.Drawing.Point(3, 135);
            this.materialRaisedButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton4.Name = "materialRaisedButton4";
            this.materialRaisedButton4.Primary = true;
            this.materialRaisedButton4.Size = new System.Drawing.Size(154, 38);
            this.materialRaisedButton4.TabIndex = 3;
            this.materialRaisedButton4.Text = "라이센스";
            this.materialRaisedButton4.UseVisualStyleBackColor = true;
            this.materialRaisedButton4.Click += new System.EventHandler(this.materialRaisedButton4_Click);
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Location = new System.Drawing.Point(3, 91);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(154, 38);
            this.materialRaisedButton3.TabIndex = 2;
            this.materialRaisedButton3.Text = "개발 시간";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            this.materialRaisedButton3.Click += new System.EventHandler(this.materialRaisedButton3_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(3, 3);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(154, 82);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "개발자";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.materialLabel13);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.materialLabel9);
            this.panel3.Controls.Add(this.materialLabel8);
            this.panel3.Controls.Add(this.materialLabel7);
            this.panel3.Controls.Add(this.materialLabel6);
            this.panel3.Controls.Add(this.materialLabel5);
            this.panel3.Location = new System.Drawing.Point(544, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 174);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(3, 115);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(297, 19);
            this.materialLabel13.TabIndex = 6;
            this.materialLabel13.Text = "Alpha :  2015 / 12.25 / AM 12 : 46 / Release";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::N사_오토_프로그램.Properties.Resources.이미지;
            this.pictureBox1.Location = new System.Drawing.Point(242, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(3, 96);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(289, 19);
            this.materialLabel9.TabIndex = 4;
            this.materialLabel9.Text = "Beta :  2015 / 12.25 / AM 02 : 02 / Release";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(3, 68);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(121, 19);
            this.materialLabel8.TabIndex = 3;
            this.materialLabel8.Text = "Material : 2 Hour";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(3, 49);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(117, 19);
            this.materialLabel7.TabIndex = 2;
            this.materialLabel7.Text = "Coding : 4 Week";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(3, 30);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(158, 19);
            this.materialLabel6.TabIndex = 1;
            this.materialLabel6.Text = "Cafe Writing : 3 Month";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(3, 9);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(112, 19);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "Design : 1 Hour";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.materialLabel4);
            this.panel2.Controls.Add(this.materialLabel3);
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Controls.Add(this.materialRaisedButton5);
            this.panel2.Location = new System.Drawing.Point(210, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 174);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::N사_오토_프로그램.Properties.Resources.이미지;
            this.pictureBox2.Location = new System.Drawing.Point(232, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(228, 117);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(82, 19);
            this.materialLabel4.TabIndex = 4;
            this.materialLabel4.Text = "Ver : Alpha";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(24, 53);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(132, 19);
            this.materialLabel3.TabIndex = 3;
            this.materialLabel3.Text = "Design : Aoi Kazto";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(24, 27);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(119, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Main : Aoi Kazto";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(4, 4);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(63, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Dev List";
            // 
            // materialRaisedButton5
            // 
            this.materialRaisedButton5.Depth = 0;
            this.materialRaisedButton5.Location = new System.Drawing.Point(3, 139);
            this.materialRaisedButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton5.Name = "materialRaisedButton5";
            this.materialRaisedButton5.Primary = true;
            this.materialRaisedButton5.Size = new System.Drawing.Size(299, 32);
            this.materialRaisedButton5.TabIndex = 0;
            this.materialRaisedButton5.Text = "블로그로 이동";
            this.materialRaisedButton5.UseVisualStyleBackColor = true;
            this.materialRaisedButton5.Click += new System.EventHandler(this.materialRaisedButton5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "N사 카페 오토 프로그램 ( By Aoi Kazto )";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialLabel Label_Login_Option;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Login;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_PW;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_ID;
        private MaterialSkin.Controls.MaterialLabel Label_PW;
        private MaterialSkin.Controls.MaterialLabel Label_ID;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Update;
        private MaterialSkin.Controls.MaterialCheckBox CheckBox_ScreenMode;
        private MaterialSkin.Controls.MaterialCheckBox CheckBox_AutoUpdate;
        private MaterialSkin.Controls.MaterialCheckBox CheckBox_AutoLogin;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Stop;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Start;
        private MaterialSkin.Controls.MaterialRaisedButton Button_SettingSave;
        private MaterialSkin.Controls.MaterialCheckBox CheckBox_HidePassword;
        private MaterialSkin.Controls.MaterialRaisedButton Pic_Hide;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Option;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox List_List;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Del;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Add;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_Title;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_CafeID;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_MenuID;
        private MaterialSkin.Controls.MaterialRaisedButton Button_Search;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_Tag;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_Content;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_Delay;
        private MaterialSkin.Controls.MaterialLabel Label;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton4;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialSingleLineTextField Text_CafeName;
        private MaterialSkin.Controls.MaterialCheckBox Check_Delete;
    }
}

