using pryAutogestionFinanzas;
using pryAutogestiónFinanzas.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryAutogestiónFinanzas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            // Evitar dobles enganches si el Designer también los tiene
            btnCarla.Click -= btnCarla_Click;
            btnCarla.Click += btnCarla_Click;

            btnChino.Click -= btnChino_Click;
            btnChino.Click += btnChino_Click;
        }

        private void SetActiveNavButton(Guna.UI2.WinForms.Guna2Button activeBtn)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.FillColor = Color.FromArgb(52, 72, 97); // normal
                    btn.ForeColor = Color.White;
                }
            }

            activeBtn.FillColor = Color.FromArgb(113, 99, 199); // activo
            activeBtn.ForeColor = Color.White;
        }

        private void btnCarla_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnCarla);
            IngresarComo("Carla");
        }

        private void btnChino_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnChino);
            IngresarComo("Chino");
        }

        private void IngresarComo(string usuario)
        {
            Session.Login(usuario);

            var menu = new frmMenuPrincipal1();

            // Cerrar login cuando se cierre el menú
            menu.FormClosed += (s, e) => this.Close();

            this.Hide();
            menu.Show();
        }
    }
}