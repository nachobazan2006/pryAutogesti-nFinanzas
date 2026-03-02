using Guna.UI2.WinForms;
using pryAutogestiónFinanzas;
using pryAutogestionFinanzas.Models;
using pryAutogestionFinanzas.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pryAutogestiónFinanzas
{
    public partial class frmGastosLibres : Form
    {




        private readonly CatalogosService _catalogosService;
        private readonly MovimientosService _movimientosService;

        public frmGastosLibres()
        {
            InitializeComponent();

            var api = new ApiClient();
            _catalogosService = new CatalogosService(api);
            _movimientosService = new MovimientosService(api);
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
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            try
            {
                var dto = new CreateMovimientoDto
                {
                    Tipo = "Egreso",
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    MedioPagoId = (int)cboMedioPago.SelectedValue,
                    Monto = decimal.Parse(txtMonto.Text),
                    Fecha = dtpFecha.Value,
                    Descripcion = txtDescripcion.Text
                };

                var creado = await _movimientosService.CreateAsync(dto);

                MessageBox.Show($"✅ Guardado! ID: {creado?.Id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }
        private async void frmGastosLibres_Load(object sender, EventArgs e)
        {
            var data = await _catalogosService.GetCatalogosAsync();

            // Solo categorías de egreso para este form:
            var categoriasEgreso = data.Categorias.Where(c => c.Tipo == "Egreso").ToList();

            cboCategoria.DataSource = categoriasEgreso;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";

            cboMedioPago.DataSource = data.MediosPago;
            cboMedioPago.DisplayMember = "Nombre";
            cboMedioPago.ValueMember = "Id";
        }
    }
}
