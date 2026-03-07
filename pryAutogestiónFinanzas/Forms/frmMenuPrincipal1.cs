using Guna.UI2.WinForms;
using pryAutogestiónFinanzas;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pryAutogestionFinanzas
{
    public partial class frmMenuPrincipal1 : Form
    {
        private Form? _formActivo = null;

        private readonly Color _botonNormal = Color.FromArgb(67, 89, 146);
        private readonly Color _botonHover = Color.FromArgb(92, 113, 173);
        private readonly Color _botonActivo = Color.FromArgb(122, 102, 214);
        private readonly Color _textoBlanco = Color.White;
        private readonly Color _fondoApp = Color.FromArgb(242, 244, 248);

        public frmMenuPrincipal1()
        {
            InitializeComponent();

            this.Load -= frmMenuPrincipal1_Load;
            this.Load += frmMenuPrincipal1_Load;

            btnGastosFijos.Click -= BtnGastosFijos_Click;
            btnGastosFijos.Click += BtnGastosFijos_Click;

            btnGastosLibres.Click -= BtnGastosLibres_Click;
            btnGastosLibres.Click += BtnGastosLibres_Click;

            btnAhorros.Click -= BtnAhorros_Click;
            btnAhorros.Click += BtnAhorros_Click;

            btnAportes.Click -= BtnAportes_Click;
            btnAportes.Click += BtnAportes_Click;

            btnIngresos.Click -= BtnIngresos_Click;
            btnIngresos.Click += BtnIngresos_Click;

            btnEstadisticas.Click -= BtnEstadisticas_Click;
            btnEstadisticas.Click += BtnEstadisticas_Click;
        }

        private void frmMenuPrincipal1_Load(object? sender, EventArgs e)
        {
            BackColor = _fondoApp;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            ConfigurarBotonesLaterales();

            ActivarBoton(btnGastosFijos);
            AbrirFormularioEnContenedor(new frmGastosFijos());
        }

        private void ConfigurarBotonesLaterales()
        {
            var botones = panelLateral.Controls.OfType<Guna2Button>().ToList();

            foreach (var btn in botones)
            {
                btn.BorderRadius = 12;
                btn.FillColor = _botonNormal;
                btn.ForeColor = _textoBlanco;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                btn.HoverState.FillColor = _botonHover;
                btn.PressedColor = _botonHover;
                btn.Animated = true;
                btn.Cursor = Cursors.Hand;
                btn.TextAlign = HorizontalAlignment.Center;
                btn.BorderThickness = 0;
                btn.BackColor = Color.Transparent;
            }
        }

        private void ActivarBoton(Guna2Button botonActivo)
        {
            foreach (var btn in panelLateral.Controls.OfType<Guna2Button>())
            {
                btn.FillColor = _botonNormal;
            }

            botonActivo.FillColor = _botonActivo;
        }

        private void AbrirFormularioEnContenedor(Form formularioHijo)
        {
            if (_formActivo != null)
            {
                _formActivo.Close();
                _formActivo.Dispose();
            }

            _formActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.Margin = Padding.Empty;
            formularioHijo.Padding = Padding.Empty;
            formularioHijo.BackColor = _fondoApp;

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;

            formularioHijo.Show();
            formularioHijo.BringToFront();
        }

        private void BtnGastosFijos_Click(object? sender, EventArgs e)
        {
            ActivarBoton(btnGastosFijos);
            AbrirFormularioEnContenedor(new frmGastosFijos());
        }

        private void BtnGastosLibres_Click(object? sender, EventArgs e)
        {
            ActivarBoton(btnGastosLibres);
            AbrirFormularioEnContenedor(new frmGastosLibres());
        }

        private void BtnAhorros_Click(object? sender, EventArgs e)
        {
            ActivarBoton(btnAhorros);
            AbrirFormularioEnContenedor(new frmAhorros());
        }

        private void BtnAportes_Click(object? sender, EventArgs e)
        {
            ActivarBoton(btnAportes);
            AbrirFormularioEnContenedor(new frmAporte());
        }

        private void BtnIngresos_Click(object? sender, EventArgs e)
        {
            ActivarBoton(btnIngresos);
            AbrirFormularioEnContenedor(new frmIngresos());
        }

        private void BtnEstadisticas_Click(object? sender, EventArgs e)
        {
            ActivarBoton(btnEstadisticas);
            AbrirFormularioEnContenedor(new frmEstadisticas());
        }

        private void btnEstadisticas_Click_1(object sender, EventArgs e)
        {

        }
    }
}