using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pryAutogestiónFinanzas
{
    public partial class frmGastosFijos : Form
    {
        public frmGastosFijos()
        {
            InitializeComponent();
        }
        private void SetActiveButton(Guna2Button btn)
        {
            foreach (Control c in panelLateral.Controls)
            {
                if (c is Guna2Button b)
                    b.FillColor = Color.FromArgb(52, 72, 97); // normal
            }

            btn.FillColor = Color.FromArgb(113, 99, 199); // activo
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

        }

    }
}
