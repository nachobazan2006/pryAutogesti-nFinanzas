using pryAutogestionFinanzas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pryAutogestiónFinanzas
{
    public partial class frmMenuPrincipal1 : Form
    {
        public frmMenuPrincipal1()
        {
            InitializeComponent();
        }
        private void frmMenuPrincipal1_Load(object sender, EventArgs e)
        {
            lblUsuarioActual.Text = $"Bienvenido, {Helpers.Session.Usuario}!";
        }
        private void AbrirFormulario(Form formHijo)
        {
            panelContenedor.Controls.Clear();

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void btnGastosFijos_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Guna.UI2.WinForms.Guna2Button)sender);
            AbrirFormulario(new frmGastosFijos());
        }

        private void btnGastosLibres_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Guna.UI2.WinForms.Guna2Button)sender);
            AbrirFormulario(new frmGastosLibres());
        }

        private void btnAportes_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Guna.UI2.WinForms.Guna2Button)sender);
            AbrirFormulario(new frmAporte());
        }

        private void btnAhorros_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Guna.UI2.WinForms.Guna2Button)sender);
            AbrirFormulario(new frmAhorros());
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Guna.UI2.WinForms.Guna2Button)sender);
            AbrirFormulario(new frmIngresos());
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Guna.UI2.WinForms.Guna2Button)sender);
            AbrirFormulario(new frmEstadisticas());
        }
        private void SetActiveNavButton(Guna.UI2.WinForms.Guna2Button activeBtn)
        {
            foreach (Control c in panelLateral.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.FillColor = Color.FromArgb(52, 72, 97); // normal
                    btn.ForeColor = Color.White;
                }
            }

            activeBtn.FillColor = Color.FromArgb(113, 99, 199); // activo (violeta)
            activeBtn.ForeColor = Color.White;
        }

 

        private void frmMenuPrincipal1_Load_1(object sender, EventArgs e)
        {

        }

        private void panelLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
