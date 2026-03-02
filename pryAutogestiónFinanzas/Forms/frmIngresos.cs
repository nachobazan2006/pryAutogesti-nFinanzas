using pryAutogestionFinanzas.Models;
using pryAutogestionFinanzas.Services;
using System.Linq;

namespace pryAutogestionFinanzas
{
    public partial class frmIngresos : Form
    {
        private readonly CatalogosService _catalogosService;
        private readonly MovimientosService _movimientosService;

        public frmIngresos()
        {
            InitializeComponent();

            this.Load += frmIngresos_Load;
            btnAgregar.Click += btnAgregar_Click;


            var api = new ApiClient();
            _catalogosService = new CatalogosService(api);
            _movimientosService = new MovimientosService(api);
        }

        private async void frmIngresos_Load(object sender, EventArgs e)
        {
            var data = await _catalogosService.GetCatalogosAsync();

            var catIngreso = data.Categorias.Where(c => c.Tipo == "Ingreso").ToList();

            cboCategoria.DataSource = catIngreso;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";

            cboMedioPago.DataSource = data.MediosPago;
            cboMedioPago.DisplayMember = "Nombre";
            cboMedioPago.ValueMember = "Id";

            dtpFecha.Value = DateTime.Now;

            // opcional: cargar ingresos ya guardados en la grilla
            await CargarIngresosEnGrilla();
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtMonto.Text, out var monto) || monto <= 0)
                {
                    MessageBox.Show("Ingresá un monto válido (> 0).");
                    return;
                }

                var dto = new CreateMovimientoDto
                {
                    Tipo = "Ingreso",
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    MedioPagoId = (int)cboMedioPago.SelectedValue,
                    Monto = monto,
                    Fecha = dtpFecha.Value,
                    Descripcion = $"{txtFuenteIngreso.Text}".Trim()
                                 + (string.IsNullOrWhiteSpace(txtNotas.Text) ? "" : $" - {txtNotas.Text.Trim()}")
                };

                var creado = await _movimientosService.CreateAsync(dto);

                MessageBox.Show($"✅ Ingreso guardado (ID {creado?.Id})");

                // limpiar
                txtMonto.Clear();
                txtFuenteIngreso.Clear();
                txtNotas.Clear();
                dtpFecha.Value = DateTime.Now;

                // refrescar grilla
                await CargarIngresosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }

        }
        private async Task CargarIngresosEnGrilla()
        {
            var lista = await _movimientosService.GetByTipoAsync("Ingreso");
            dgvIngresos.DataSource = lista;
        }
    }
}