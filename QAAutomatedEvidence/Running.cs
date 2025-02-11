using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace QAAutomatedEvidence
{
    public partial class Running : Form
    {
        //private static string evidenciasPath = @"C:\temp\";
        private static string executionPath = @"";
        private static IntPtr hookID = IntPtr.Zero;
        private string testname;
        private string suitename;
        private string environment;
        private List<SectionData> sections = new List<SectionData> { new SectionData("Default") };

        public Running(string scenario, string suite, string cbbIndex)
        {
            this.testname = scenario;
            this.suitename = suite;
            this.environment = cbbIndex;

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            PositionInBottomRight();

            var testnameProcessed = scenario.Replace(" ", "_");
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            executionPath = Path.Combine(@"C:\temp\", $"{testnameProcessed}_{timestamp}");

            if (!Directory.Exists(executionPath))
            {
                Directory.CreateDirectory(executionPath);
            }
            hookID = SetHook(HookCallback);
            InitializeComponent();
        }

        private void PositionInBottomRight()
        {
            this.StartPosition = FormStartPosition.Manual;

            // Aguarda o layout ser finalizado antes de definir a posição
            this.Load += (s, e) =>
            {
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                // Define a posição corrigida, garantindo que fique acima da barra de tarefas
                this.Location = new Point(screenWidth - this.Width - 10, screenHeight - this.Height - 10);
            };
        }


        private void btn_capture_Click(object sender, EventArgs e)
        {
            CapturarTela();
        }

        private void CapturarTela()
        {
            try
            {
                string fileName = $"Evidencia_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string caminho = Path.Combine(executionPath, fileName);

                Bitmap captura = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                using (Graphics g = Graphics.FromImage(captura))
                {
                    g.CopyFromScreen(0, 0, 0, 0, captura.Size);
                }

                captura.Save(caminho, System.Drawing.Imaging.ImageFormat.Png);

                SectionData lastSection = sections.LastOrDefault() ?? sections.FirstOrDefault(s => s.Name == "Default");

                if (!sections.Contains(lastSection))
                {
                    sections.Add(lastSection);
                }

                lastSection.Evidences.Add(caminho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao capturar tela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            GerarRelatorio("Sucesso");
            Close();
            RestaurarMain();
        }

        private void btn_fail_Click(object sender, EventArgs e)
        {
            GerarRelatorio("Falha");
            this.Close();
            RestaurarMain();
        }

        private void RestaurarMain()
        {
            MainApp formPrincipal = Application.OpenForms["MainApp"] as MainApp;
            if (formPrincipal != null)
            {
                formPrincipal.RestaurarDaBandeja();
            }
        }

        public void GerarRelatorio(string status)
        {
            try
            {
                string userName = GetWindowsUserName();
                string data = DateTime.Now.ToString("dd/MM/yyyy");
                string hora = DateTime.Now.ToString("HH:mm:ss");
                string fileName = $"Relatorio_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = Path.Combine(executionPath, fileName);

                var document = new Document();
                Section section = document.AddSection();

                //AddHeaderWithImage(section);

                section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
                section.PageSetup.RightMargin = Unit.FromCentimeter(1);
                section.PageSetup.TopMargin = Unit.FromCentimeter(2);
                section.PageSetup.BottomMargin = Unit.FromCentimeter(1.5);

                Paragraph title = section.AddParagraph("Relatório de Execução");
                title.Format.Font.Size = 18;
                title.Format.Font.Bold = true;
                title.Format.Alignment = ParagraphAlignment.Center;
                title.Format.SpaceAfter = Unit.FromCentimeter(0.8);

                Paragraph statusexec = section.AddParagraph("Status da Execução");
                statusexec.Format.Font.Size = 14;
                statusexec.Format.Font.Bold = true;
                statusexec.Format.Alignment = ParagraphAlignment.Center;

                Paragraph statusexecValue = section.AddParagraph(status);
                statusexecValue.Format.Font.Size = 14;
                statusexecValue.Format.Font.Italic = true;
                statusexecValue.Format.Alignment = ParagraphAlignment.Center;
                statusexecValue.Format.SpaceAfter = Unit.FromCentimeter(0.5);
                statusexecValue.Format.Font.Color = status.ToLower() == "sucesso" ? Colors.Green : Colors.Red;

                AddSeparator(section);

                Table table = section.AddTable();
                table.Borders.Width = 0.0;
                table.Format.Alignment = ParagraphAlignment.Left;
                table.Rows.LeftIndent = 0;

                Column col1 = table.AddColumn(Unit.FromCentimeter(4));
                Column col2 = table.AddColumn(Unit.FromCentimeter(14));

                AddTableRow(table, "Usuário/Testador:", userName);
                AddTableRow(table, "Data:", data);
                AddTableRow(table, "Hora:", hora);
                AddTableRow(table, "Suíte:", suitename);
                AddTableRow(table, "TestCase:", testname);
                AddTableRow(table, "Ambiente:", environment);
                AddTableRow(table, "Status:", status);

                string observacao = ShowInputDialog("Observações", "Digite observações adicionais (opcional):");
                if (!string.IsNullOrWhiteSpace(observacao))
                {
                    AddTableRow(table, "Observações:", observacao);
                }

                AddSeparator(section);

                section.AddParagraph("\nEvidências:").Format.Font.Bold = true;

                foreach (var sec in sections)
                {
                    section.AddParagraph($"\nSeção: {sec.Name}").Format.Font.Bold = true;

                    if (sec.Evidences.Count == 0)
                    {
                        section.AddParagraph("Nenhuma evidência registrada.");
                    }
                    else
                    {
                        foreach (string imagem in sec.Evidences)
                        {
                            section.AddParagraph($"\nImagem: {Path.GetFileName(imagem)}");
                            MigraDoc.DocumentObjectModel.Shapes.Image image = section.AddImage(imagem);
                            image.Width = Unit.FromCentimeter(18.9);
                            image.LockAspectRatio = true;
                        }
                    }
                    AddSeparator(section);
                }

                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
                {
                    Document = document
                };
                renderer.RenderDocument();
                renderer.PdfDocument.Save(filePath);

                MessageBox.Show($"Relatório gerado em: {filePath}", "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTableRow(Table table, string title, string value)
        {
            Row row = table.AddRow();
            row.Cells[0].AddParagraph(title).Format.Font.Bold = true;
            Paragraph valueParagraph = row.Cells[1].AddParagraph(value);
            valueParagraph.Format.Alignment = ParagraphAlignment.Left;

            if (title.ToLower() == "status:")
            {
                valueParagraph.Format.Font.Bold = true;
                valueParagraph.Format.Font.Color = value.ToLower() == "sucesso" ? Colors.Green : Colors.Red;
            }
        }

        private void AddSeparator(Section section)
        {
            Paragraph separator = section.AddParagraph();
            separator.Format.Borders.Bottom.Width = 1;
            separator.Format.SpaceAfter = Unit.FromCentimeter(0.5);
        }

        private string GetWindowsUserName()
        {
            try
            {
                return System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
            }
            catch
            {
                return Environment.UserName;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            // Passar o caminho para MainApp
            MainApp formPrincipal = Application.OpenForms["MainApp"] as MainApp;
            if (formPrincipal != null && !string.IsNullOrEmpty(executionPath))
            {
                formPrincipal.AtualizarCaminhoEvidencia(executionPath);
            }
            base.OnFormClosing(e);
            UnhookWindowsHookEx(hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            const int WM_KEYDOWN = 0x0100;
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == Keys.F12)
                {
                    Application.OpenForms["Running"].Invoke((MethodInvoker)delegate
                    {
                        ((Running)Application.OpenForms["Running"]).CapturarTela();
                    });
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private const int WH_KEYBOARD_LL = 13;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        private void btn_newsection_Click(object sender, EventArgs e)
        {
            string newSectionName = ShowInputDialog("Nova Seção", "Digite o nome da nova seção:");

            if (!string.IsNullOrWhiteSpace(newSectionName))
            {
                if (!sections.Any(s => s.Name == newSectionName))
                {
                    sections.Add(new SectionData(newSectionName));
                }
            }
        }

        /// <summary>
        /// Exibe uma caixa de diálogo para entrada do usuário.
        /// </summary>
        private string ShowInputDialog(string title, string promptText)
        {
            Form inputForm = new Form()
            {
                Width = 400,
                Height = 220,
                ControlBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Text = title
            };

            Label label = new Label() { Left = 20, Top = 20, Text = promptText, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmButton = new Button() { Text = "Add", Left = 150, Width = 100, Top = 100, Height = 50, DialogResult = DialogResult.OK };

            inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(confirmButton);
            inputForm.AcceptButton = confirmButton;

            return inputForm.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : string.Empty;
        }
    }
}
