using Guna.UI2.WinForms;
using pryAutogestionFinanzas.Models;
using pryAutogestionFinanzas.Services;
using pryAutoGestionFinanzas.Models;
using pryAutogestiónFinanzas.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAutogestionFinanzas
{
    public partial class frmGastosFijos : Form
    {
        private readonly CatalogosService _catalogosService;
        private readonly MovimientosService _movimientosService;

        // Modo edición
        private bool _modoEdicion = false;
        private int? _idEditando = null;
        private string _creadoPorEditando = "";

        public frmGastosFijos()
        {
            InitializeComponent();

            var api = new ApiClient();
            _catalogosService = new CatalogosService(api);
            _movimientosService = new MovimientosService(api);

            // Evita dobles enganches
            this.Load -= frmGastosFijos_Load;
            this.Load += frmGastosFijos_Load;

            dgvMovimientos.CellClick -= dgvMovimientos_CellClick;
            dgvMovimientos.CellClick += dgvMovimientos_CellClick;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnAgregar.Click -= btnAgregar_Click;
            btnAgregar.Click += btnAgregar_Click;

            btnCancelarEdicion.Click -= btnCancelar_Click;
            btnCancelarEdicion.Click += btnCancelar_Click;
        }

        // --------------------------
        // LOAD
        // --------------------------
        private async void frmGastosFijos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                await CargarCatalogosAsync();
                await CargarFijosEnGrillaAsync();
                SalirModoEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Load: " + ex.Message);
            }
        }

        // --------------------------
        // CARGAR CATEGORÍAS Y MEDIOS
        // --------------------------
        private async Task CargarCatalogosAsync()
        {
            var data = await _catalogosService.GetCatalogosAsync();

            var categoriasEgreso = data.Categorias
                .Where(c => string.Equals((c.Tipo ?? "").Trim(), "Egreso", StringComparison.OrdinalIgnoreCase))
                .ToList();

            cboCategoria.DataSource = categoriasEgreso;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";

            cboMedioPago.DataSource = data.MediosPago;
            cboMedioPago.DisplayMember = "Nombre";
            cboMedioPago.ValueMember = "Id";
        }

        // --------------------------
        // CARGAR SOLO FIJOS EN GRILLA
        // --------------------------
        private async Task CargarFijosEnGrillaAsync()
        {
            var lista = await _movimientosService.GetByTipoAsync("Egreso");

            var fijos = lista
                .Where(x => (x.Descripcion ?? "").TrimStart().StartsWith("[FIJO]", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(x => x.Fecha)
                .Select(MapToGridRow)
                .ToList();

            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = fijos;
            dgvMovimientos.ClearSelection();
        }

        private static GastoFijoGridRow MapToGridRow(MovimientoDto x)
        {
            var desc = (x.Descripcion ?? "").Trim();

            var sinPrefijo = desc;
            if (sinPrefijo.StartsWith("[FIJO]", StringComparison.OrdinalIgnoreCase))
                sinPrefijo = sinPrefijo.Substring(6).Trim();

            string nombre = sinPrefijo;
            string notas = "";

            var partes = sinPrefijo.Split(new[] { "|Notas:" }, StringSplitOptions.None);
            if (partes.Length >= 1) nombre = partes[0].Trim();
            if (partes.Length >= 2) notas = partes[1].Trim();

            if (partes.Length == 1 && sinPrefijo.Contains("\nNotas:"))
            {
                var p2 = sinPrefijo.Split(new[] { "\nNotas:" }, StringSplitOptions.None);
                nombre = (p2.Length >= 1 ? p2[0] : "").Trim();
                notas = (p2.Length >= 2 ? p2[1] : "").Trim();
            }

            return new GastoFijoGridRow
            {
                Id = x.Id,
                NombreGasto = nombre,
                Categoria = x.Categoria ?? "",
                Monto = x.Monto,
                Vencimiento = x.Fecha,
                MedioPago = x.MedioPago ?? "",
                Notas = notas,
                CreadoPor = x.CreadoPor ?? ""
            };
        }

        // --------------------------
        // CONFIGURAR GRILLA
        // --------------------------
        private void ConfigurarGrilla()
        {
            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AllowUserToResizeRows = false;
            dgvMovimientos.RowHeadersVisible = false;

            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvMovimientos.BackgroundColor = Color.FromArgb(12, 18, 35);
            dgvMovimientos.GridColor = Color.FromArgb(35, 45, 70);

            dgvMovimientos.ColumnHeadersHeight = 42;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 28, 52);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvMovimientos.DefaultCellStyle.BackColor = Color.FromArgb(12, 18, 35);
            dgvMovimientos.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgvMovimientos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 90, 180);
            dgvMovimientos.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(14, 22, 42);

            if (dgvMovimientos.Columns.Contains("colId"))
            {
                dgvMovimientos.Columns["colId"].DataPropertyName = "Id";
                dgvMovimientos.Columns["colId"].Visible = false;
            }

            if (dgvMovimientos.Columns.Contains("colNombreGasto"))
                dgvMovimientos.Columns["colNombreGasto"].DataPropertyName = "NombreGasto";

            if (dgvMovimientos.Columns.Contains("colCategoria"))
                dgvMovimientos.Columns["colCategoria"].DataPropertyName = "Categoria";

            if (dgvMovimientos.Columns.Contains("colMonto"))
            {
                dgvMovimientos.Columns["colMonto"].DataPropertyName = "Monto";
                dgvMovimientos.Columns["colMonto"].DefaultCellStyle.Format = "N0";
                dgvMovimientos.Columns["colMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvMovimientos.Columns.Contains("colVencimiento"))
            {
                dgvMovimientos.Columns["colVencimiento"].DataPropertyName = "Vencimiento";
                dgvMovimientos.Columns["colVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvMovimientos.Columns.Contains("colMedioPago"))
                dgvMovimientos.Columns["colMedioPago"].DataPropertyName = "MedioPago";

            if (dgvMovimientos.Columns.Contains("colNotas"))
                dgvMovimientos.Columns["colNotas"].DataPropertyName = "Notas";

            // 👇 PREPARADO para mostrar usuario si agregás la columna
            if (dgvMovimientos.Columns.Contains("colCreadoPor"))
                dgvMovimientos.Columns["colCreadoPor"].DataPropertyName = "CreadoPor";
        }

        // --------------------------
        // SELECCIÓN EN GRILLA
        // --------------------------
        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PrecargarDesdeFilaSeleccionada();
        }

        private void PrecargarDesdeFilaSeleccionada()
        {
            if (dgvMovimientos.CurrentRow?.DataBoundItem is not GastoFijoGridRow row) return;

            _idEditando = row.Id;
            _creadoPorEditando = row.CreadoPor ?? "";

            txtNombreGasto.Text = row.NombreGasto;
            txtMonto.Text = row.Monto.ToString("0.##");
            txtNotas.Text = row.Notas;
            dtpVencimiento.Value = row.Vencimiento;

            SeleccionarComboPorTexto(cboCategoria, row.Categoria);
            SeleccionarComboPorTexto(cboMedioPago, row.MedioPago);
        }

        private static void SeleccionarComboPorTexto(ComboBox combo, string texto)
        {
            if (combo.DataSource == null) return;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                combo.SelectedIndex = i;
                var current = combo.Text?.Trim() ?? "";
                if (string.Equals(current, texto?.Trim() ?? "", StringComparison.OrdinalIgnoreCase))
                    return;
            }
        }

        // --------------------------
        // BOTÓN EDITAR
        // --------------------------
        private void btnEditar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            if (dgvMovimientos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un gasto fijo de la tabla para editar.");
                return;
            }

            PrecargarDesdeFilaSeleccionada();

            if (_idEditando == null)
            {
                MessageBox.Show("No se pudo obtener el ID del registro (revisá colId).");
                return;
            }

            EntrarModoEdicion();
        }

        private void EntrarModoEdicion()
        {
            _modoEdicion = true;
            btnAgregar.Text = "Actualizar";
        }

        private void SalirModoEdicion()
        {
            _modoEdicion = false;
            _idEditando = null;
            _creadoPorEditando = "";
            btnAgregar.Text = "Agregar";
            dgvMovimientos.ClearSelection();
        }

        // --------------------------
        // BOTÓN ELIMINAR
        // --------------------------
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            if (dgvMovimientos.CurrentRow?.DataBoundItem is not GastoFijoGridRow row)
            {
                MessageBox.Show("Seleccioná un gasto fijo para eliminar.");
                return;
            }

            var ok = MessageBox.Show(
                $"¿Eliminar el gasto fijo '{row.NombreGasto}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (ok != DialogResult.Yes) return;

            try
            {
                await _movimientosService.DeleteAsync(row.Id);
                MessageBox.Show("✅ Eliminado.");

                LimpiarFormulario();
                SalirModoEdicion();
                await CargarFijosEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al eliminar: " + ex.Message);
            }
        }

        // --------------------------
        // AGREGAR / ACTUALIZAR
        // --------------------------
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            try
            {
                var nombre = (txtNombreGasto.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingresá el nombre del gasto.");
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Monto inválido.");
                    return;
                }

                var notas = (txtNotas.Text ?? "").Trim();
                var descripcionFinal = $"[FIJO] {nombre}|Notas: {notas}";

                var creadoPor = _modoEdicion
                    ? (string.IsNullOrWhiteSpace(_creadoPorEditando) ? Session.Usuario : _creadoPorEditando)
                    : Session.Usuario;

                var dto = new CreateMovimientoDto
                {
                    Tipo = "Egreso",
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    MedioPagoId = (int)cboMedioPago.SelectedValue,
                    Monto = monto,
                    Fecha = dtpVencimiento.Value,
                    Descripcion = descripcionFinal,
                    CreadoPor = creadoPor
                };

                if (_modoEdicion)
                {
                    if (_idEditando == null)
                    {
                        MessageBox.Show("No hay ID para actualizar. Seleccioná un registro y tocá Editar.");
                        return;
                    }

                    await _movimientosService.UpdateAsync(_idEditando.Value, dto);
                    MessageBox.Show("✅ Actualizado.");
                }
                else
                {
                    await _movimientosService.CreateAsync(dto);
                    MessageBox.Show("✅ Guardado.");
                }

                LimpiarFormulario();
                SalirModoEdicion();
                await CargarFijosEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }

        // --------------------------
        // LIMPIAR FORM
        // --------------------------
        private void LimpiarFormulario()
        {
            txtNombreGasto.Clear();
            txtMonto.Clear();
            txtNotas.Clear();
            dtpVencimiento.Value = DateTime.Now;

            cboCategoria.SelectedIndex = cboCategoria.Items.Count > 0 ? 0 : -1;
            cboMedioPago.SelectedIndex = cboMedioPago.Items.Count > 0 ? 0 : -1;
        }

        // --------------------------
        // UI
        // --------------------------
        private void SetActiveButton(Guna2Button btn)
        {
            foreach (Control c in panelLateral.Controls)
            {
                if (c is Guna2Button b)
                    b.FillColor = Color.FromArgb(52, 72, 97);
            }
            btn.FillColor = Color.FromArgb(113, 99, 199);
        }

        // --------------------------
        // ViewModel para grilla
        // --------------------------
        private class GastoFijoGridRow
        {
            public int Id { get; set; }
            public string NombreGasto { get; set; } = "";
            public string Categoria { get; set; } = "";
            public decimal Monto { get; set; }
            public DateTime Vencimiento { get; set; }
            public string MedioPago { get; set; } = "";
            public string Notas { get; set; } = "";
            public string CreadoPor { get; set; } = "";
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                SalirModoEdicion();
                LimpiarFormulario();
                dgvMovimientos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar: " + ex.Message);
            }
        }
    }
}