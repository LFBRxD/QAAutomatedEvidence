namespace QAAutomatedEvidence
{
    public partial class MainApp : Form
    {
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip trayMenu;
        public MainApp()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (this.txt_scenario.Text.Length <= 5 || this.txt_suite.Text.Length <= 5)
            {
                this.lbl_error.Text = "Erro: campo de suite ou cenário não está preenchido corretamente";
                this.lbl_error.ForeColor = Color.Red;
                return;
            }
            else
            {
                this.lbl_error.Text = "";
            }

            // Minimiza para a bandeja
            notifyIcon1.Visible = true;
            this.Hide(); // Esconde o FormPrincipal

            // Abre o segundo formul�rio
            //Running formSecundario = new Running();
           // formSecundario.Show();
        }

        private void group_userinfo_Enter(object sender, EventArgs e)
        {

        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            // Configurar informações do usuário
            this.username.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.datetime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.lbl_error.Text = "";

            // Configurar ComboBox
            List<string> opcoes = new List<string> { "UAT", "PROD", "DEV" };
            this.cbb_env.DataSource = opcoes;
            this.cbb_env.DropDownStyle = ComboBoxStyle.DropDownList;

            // Criar o menu de contexto ANTES do NotifyIcon
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Abrir", null, AbrirApp);
            trayMenu.Items.Add("Resetar Execução", null, ResetarExecucao);
            trayMenu.Items.Add("Sair", null, FecharApp);

            // Criar o NotifyIcon (ícone da bandeja)
            notifyIcon1 = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                ContextMenuStrip = trayMenu, // Definir o menu de contexto
                Visible = false,
                Text = "Meu App"
            };

            notifyIcon1.DoubleClick += (s, e) => AbrirApp(s, e);
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick; // Adicionar evento de clique direito
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                trayMenu.Show(Cursor.Position); // Exibir o menu de contexto no cursor
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            notifyIcon1.Dispose(); 
            Application.Exit();
        }

        public void AbrirApp(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void ResetarExecucao(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void FecharApp(object sender, EventArgs e)
        {
            notifyIcon1.Dispose(); 
            Application.Exit();
        }
    }
}
