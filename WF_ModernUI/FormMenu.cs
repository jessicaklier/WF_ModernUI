using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WF_ModernUI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close(); // para fechar o meu botão
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // representa se o formulario esta
            btnRestaurar.Visible = true; // Maximizado, minimizado ou normal.
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;

        }

        private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelConteudo.Controls.OfType<Forms>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form1>();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form2>();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form3>();
        }

        private void btnContas_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form4>();
        }
    }

    namespace CShp_ComboTextBox
    {
        public partial class FormMenu : Form
        {
            public const int WM_NCLBUTTONDOWN = 0xA1; // quando o usuario pressiona o botão esquerdo do mouse.
            public const int HT_CAPTION = 0x2; // não achei o significado ainda...

            [DllImport("User32.dll")] // indica que o método atribuido é imposto por uma dll(biblioteca de vinculo dinamico.)
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lparam);
            [DllImport("User32.dll")]
            public static extern bool ReleaseCapture();
        }
        namespace CShp_ComboTextBox
        {
            public partial class FormMenu : Form
            {
                public const int WM_NCLBUTTONDOWN = 0xA1; // quando o usuario pressiona o botão esquerdo do mouse.
                public const int HT_CAPTION = 0x2; // não achei o significado ainda...

                [DllImport("User32.dll")] // indica que o método atribuido é imposto por uma dll(biblioteca de vinculo dinamico.)
                public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lparam);
                [DllImport("User32.dll")]
                public static extern bool ReleaseCapture();

                private void panelCabecalho_MouseMove(object sender, MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ReleaseCapture();
                        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    }
                }
            }
        }
    }
}

