using System.Diagnostics;

namespace QAAutomatedEvidence
{
    public partial class MainApp : Form
    {
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip trayMenu;
        public MainApp()
        {
            InitializeComponent();
            this.Icon = new Icon("Assets/app_icon.ico");

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


            Running formSecundario = new Running(this.txt_scenario.Text, this.txt_suite.Text, this.cbb_env.SelectedItem.ToString());
            formSecundario.Show();
        }

        public void RestaurarDaBandeja()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void group_userinfo_Enter(object sender, EventArgs e)
        {

        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            // Configurar informações do usuário
            this.login.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.username.Text = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
            this.datetime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.lbl_error.Text = "";
            this.lnk_lastPath.Visible = false;

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
                Icon = new Icon("Assets/app_icon.ico"),
                ContextMenuStrip = trayMenu, // Definir o menu de contexto
                Visible = false,
                Text = "Meu App"
            };

            notifyIcon1.DoubleClick += (s, e) => AbrirApp(s, e);
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick; // Adicionar evento de clique direito

            // Running formSecundario = new Running("cenário1", "testeSuite", "UAT");
            //formSecundario.GerarRelatorio("Sucesso");
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

        public void AtualizarCaminhoEvidencia(string caminho)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AtualizarCaminhoEvidencia(caminho)));
            }
            else
            {
                lnk_lastPath.Text = "Abrir Evidências da ultima execução";
                lnk_lastPath.Links.Clear();
                lnk_lastPath.Links.Add(0, lnk_lastPath.Text.Length, caminho);
                lnk_lastPath.Visible = true; // Garante que o LabelLink fique visível
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

        private void lnk_lastPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string caminho = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(caminho) && Directory.Exists(caminho))
            {
                Process.Start("explorer.exe", caminho);
            }
        }
    }
}
