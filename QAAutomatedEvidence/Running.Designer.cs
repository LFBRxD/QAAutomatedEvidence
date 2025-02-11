namespace QAAutomatedEvidence
{
    partial class Running
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_capture = new Button();
            btn_newsection = new Button();
            btn_pass = new Button();
            btn_fail = new Button();
            gbResultado = new GroupBox();
            gbResultado.SuspendLayout();
            SuspendLayout();
            // 
            // btn_capture
            // 
            btn_capture.Location = new Point(18, 27);
            btn_capture.Name = "btn_capture";
            btn_capture.Size = new Size(152, 70);
            btn_capture.TabIndex = 0;
            btn_capture.Text = "Screenshot";
            btn_capture.UseVisualStyleBackColor = true;
            btn_capture.Click += btn_capture_Click;
            // 
            // btn_newsection
            // 
            btn_newsection.Location = new Point(18, 114);
            btn_newsection.Name = "btn_newsection";
            btn_newsection.Size = new Size(152, 70);
            btn_newsection.TabIndex = 1;
            btn_newsection.Text = "Nova seção";
            btn_newsection.UseVisualStyleBackColor = true;
            btn_newsection.Click += btn_newsection_Click;
            // 
            // btn_pass
            // 
            btn_pass.BackColor = Color.Chartreuse;
            btn_pass.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_pass.Location = new Point(6, 30);
            btn_pass.Name = "btn_pass";
            btn_pass.Size = new Size(152, 70);
            btn_pass.TabIndex = 2;
            btn_pass.Text = "Sucesso";
            btn_pass.UseVisualStyleBackColor = false;
            btn_pass.Click += btn_pass_Click;
            // 
            // btn_fail
            // 
            btn_fail.BackColor = Color.Red;
            btn_fail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_fail.Location = new Point(6, 106);
            btn_fail.Name = "btn_fail";
            btn_fail.Size = new Size(152, 70);
            btn_fail.TabIndex = 3;
            btn_fail.Text = "Falha";
            btn_fail.UseVisualStyleBackColor = false;
            btn_fail.Click += btn_fail_Click;
            // 
            // gbResultado
            // 
            gbResultado.Controls.Add(btn_fail);
            gbResultado.Controls.Add(btn_pass);
            gbResultado.Location = new Point(12, 214);
            gbResultado.Name = "gbResultado";
            gbResultado.Size = new Size(168, 190);
            gbResultado.TabIndex = 4;
            gbResultado.TabStop = false;
            gbResultado.Text = "Resultado";
            // 
            // Running
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(190, 417);
            ControlBox = false;
            Controls.Add(btn_newsection);
            Controls.Add(btn_capture);
            Controls.Add(gbResultado);
            Name = "Running";
            Text = "Running";
            gbResultado.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_capture;
        private Button btn_newsection;
        private Button btn_pass;
        private Button btn_fail;
        private GroupBox gbResultado;
    }
}