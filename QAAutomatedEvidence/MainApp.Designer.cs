namespace QAAutomatedEvidence
{
    partial class MainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            lbl_appver = new LinkLabel();
            group_userinfo = new GroupBox();
            lbl_testcase = new Label();
            lbl_suite = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            lbl_testenv = new Label();
            cbb_env = new ComboBox();
            label4 = new Label();
            lbl_extra = new Label();
            datetime = new Label();
            lbl_data = new Label();
            username = new Label();
            lbl_user = new Label();
            lbl_error = new Label();
            btn_settings = new Button();
            btn_start = new Button();
            group_userinfo.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_appver
            // 
            lbl_appver.AutoSize = true;
            lbl_appver.Location = new Point(651, 510);
            lbl_appver.Name = "lbl_appver";
            lbl_appver.Size = new Size(115, 25);
            lbl_appver.TabIndex = 0;
            lbl_appver.TabStop = true;
            lbl_appver.Text = "app ver 0.1.0";
            // 
            // group_userinfo
            // 
            group_userinfo.Controls.Add(lbl_testcase);
            group_userinfo.Controls.Add(lbl_suite);
            group_userinfo.Controls.Add(textBox2);
            group_userinfo.Controls.Add(textBox1);
            group_userinfo.Controls.Add(lbl_testenv);
            group_userinfo.Controls.Add(cbb_env);
            group_userinfo.Controls.Add(label4);
            group_userinfo.Controls.Add(lbl_extra);
            group_userinfo.Controls.Add(datetime);
            group_userinfo.Controls.Add(lbl_data);
            group_userinfo.Controls.Add(username);
            group_userinfo.Controls.Add(lbl_user);
            group_userinfo.Location = new Point(27, 27);
            group_userinfo.Name = "group_userinfo";
            group_userinfo.Size = new Size(547, 429);
            group_userinfo.TabIndex = 1;
            group_userinfo.TabStop = false;
            group_userinfo.Text = "Dados do testador";
            // 
            // lbl_testcase
            // 
            lbl_testcase.AutoSize = true;
            lbl_testcase.Location = new Point(21, 330);
            lbl_testcase.Name = "lbl_testcase";
            lbl_testcase.Size = new Size(119, 25);
            lbl_testcase.TabIndex = 13;
            lbl_testcase.Text = "Caso de teste";
            // 
            // lbl_suite
            // 
            lbl_suite.AutoSize = true;
            lbl_suite.Location = new Point(21, 272);
            lbl_suite.Name = "lbl_suite";
            lbl_suite.Size = new Size(51, 25);
            lbl_suite.TabIndex = 12;
            lbl_suite.Text = "Suíte";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(144, 327);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(386, 31);
            textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 269);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(386, 31);
            textBox1.TabIndex = 10;
            // 
            // lbl_testenv
            // 
            lbl_testenv.AutoSize = true;
            lbl_testenv.Location = new Point(21, 208);
            lbl_testenv.Name = "lbl_testenv";
            lbl_testenv.Size = new Size(89, 25);
            lbl_testenv.TabIndex = 7;
            lbl_testenv.Text = "Ambiente";
            // 
            // cbb_env
            // 
            cbb_env.FormattingEnabled = true;
            cbb_env.ImeMode = ImeMode.NoControl;
            cbb_env.Location = new Point(144, 205);
            cbb_env.Name = "cbb_env";
            cbb_env.Size = new Size(182, 33);
            cbb_env.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(144, 146);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 5;
            label4.Text = "Nome";
            // 
            // lbl_extra
            // 
            lbl_extra.AutoSize = true;
            lbl_extra.Location = new Point(21, 146);
            lbl_extra.Name = "lbl_extra";
            lbl_extra.Size = new Size(50, 25);
            lbl_extra.TabIndex = 4;
            lbl_extra.Text = "extra";
            // 
            // datetime
            // 
            datetime.AutoSize = true;
            datetime.Location = new Point(144, 93);
            datetime.Name = "datetime";
            datetime.Size = new Size(61, 25);
            datetime.TabIndex = 3;
            datetime.Text = "Nome";
            // 
            // lbl_data
            // 
            lbl_data.AutoSize = true;
            lbl_data.Location = new Point(21, 93);
            lbl_data.Name = "lbl_data";
            lbl_data.Size = new Size(49, 25);
            lbl_data.TabIndex = 2;
            lbl_data.Text = "Data";
            // 
            // username
            // 
            username.AutoSize = true;
            username.Location = new Point(144, 45);
            username.Name = "username";
            username.Size = new Size(61, 25);
            username.TabIndex = 1;
            username.Text = "Nome";
            // 
            // lbl_user
            // 
            lbl_user.AutoSize = true;
            lbl_user.Location = new Point(21, 45);
            lbl_user.Name = "lbl_user";
            lbl_user.Size = new Size(61, 25);
            lbl_user.TabIndex = 0;
            lbl_user.Text = "Nome";
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Location = new Point(48, 469);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(50, 25);
            lbl_error.TabIndex = 6;
            lbl_error.Text = "error";
            // 
            // btn_settings
            // 
            btn_settings.Location = new Point(608, 40);
            btn_settings.Name = "btn_settings";
            btn_settings.Size = new Size(142, 81);
            btn_settings.TabIndex = 7;
            btn_settings.Text = "Configurações";
            btn_settings.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            btn_start.Location = new Point(608, 280);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(142, 130);
            btn_start.TabIndex = 9;
            btn_start.Text = "Iniciar";
            btn_start.UseVisualStyleBackColor = true;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 544);
            Controls.Add(btn_start);
            Controls.Add(btn_settings);
            Controls.Add(lbl_error);
            Controls.Add(group_userinfo);
            Controls.Add(lbl_appver);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "App";
            group_userinfo.ResumeLayout(false);
            group_userinfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel lbl_appver;
        private GroupBox group_userinfo;
        private Label label4;
        private Label lbl_extra;
        private Label datetime;
        private Label lbl_data;
        private Label username;
        private Label lbl_user;
        private Label lbl_error;
        private Label lbl_testenv;
        private ComboBox cbb_env;
        private Button btn_settings;
        private Button btn_start;
        private TextBox textBox1;
        private Label lbl_testcase;
        private Label lbl_suite;
        private TextBox textBox2;
    }
}
