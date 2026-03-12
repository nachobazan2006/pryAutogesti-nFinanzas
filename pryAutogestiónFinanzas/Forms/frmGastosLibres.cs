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
    public partial class frmGastosLibres : Form
    {
        private readonly CatalogosService _catalogosService;
        private readonly MovimientosService _movimientosService;

        // Modo edición
        private bool _modoEdicion = false;
        private int? _idEditando = null;
        private string _creadoPorEditando = "";

        public frmGastosLibres()
        {
            InitializeComponent();

            var api = new ApiClient();
            _catalogosService = new CatalogosService(api);
            _movimientosService = new MovimientosService(api);

            // Evita dobles enganches
            this.Load -= frmGastosLibres_Load;
            this.Load += frmGastosLibres_Load;

            dgvMovimientos.CellClick -= dgvMovimientos_CellClick;
            dgvMovimientos.CellClick += dgvMovimientos_CellClick;

            btnAgregar.Click -= btnAgregar_Click;
            btnAgregar.Click += btnAgregar_Click;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnCancelarEdicion.Click -= btnCancelar_Click;
            btnCancelarEdicion.Click += btnCancelar_Click;
        }

        // --------------------------
        // LOAD
        // --------------------------
        private async void frmGastosLibres_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                await CargarCatalogosAsync();
                await CargarEgresosEnGrillaAsync();

                SalirModoEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error en Load: " + ex.Message);
            }
        }

        // --------------------------
        // CARGA DE CATÁLOGOS
        // --------------------------
        private async Task CargarCatalogosAsync()
        {
            var data = await _catalogosService.GetCatalogosAsync();

            var categorias = data?.Categorias ?? Enumerable.Empty<CategoriaDto>();
            var medios = data?.MediosPago ?? Enumerable.Empty<MedioPagoDto>();

            var categoriasEgreso = categorias
                .Where(c => (c.Tipo ?? "").Trim().Equals("Egreso", StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Nombre)
                .ToList();

            cboCategoria.DataSource = categoriasEgreso;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedIndex = categoriasEgreso.Count > 0 ? 0 : -1;

            var mediosList = medios.OrderBy(m => m.Nombre).ToList();
            cboMedioPago.DataSource = mediosList;
            cboMedioPago.DisplayMember = "Nombre";
            cboMedioPago.ValueMember = "Id";
            cboMedioPago.SelectedIndex = mediosList.Count > 0 ? 0 : -1;
        }

        // --------------------------
        // GRID STYLE + MAPEOS
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
            dgvMovimientos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMovimientos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvMovimientos.BackgroundColor = Color.FromArgb(12, 18, 35);
            dgvMovimientos.GridColor = Color.FromArgb(35, 45, 70);

            dgvMovimientos.ColumnHeadersHeight = 42;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 28, 52);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvMovimientos.DefaultCellStyle.BackColor = Color.FromArgb(12, 18, 35);
            dgvMovimientos.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgvMovimientos.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvMovimientos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 90, 180);
            dgvMovimientos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMovimientos.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(14, 22, 42);
            dgvMovimientos.AlternatingRowsDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgvMovimientos.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 90, 180);
            dgvMovimientos.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            if (dgvMovimientos.Columns.Contains("colId"))
            {
                dgvMovimientos.Columns["colId"].DataPropertyName = "Id";
                dgvMovimientos.Columns["colId"].Visible = false;
            }

            if (dgvMovimientos.Columns.Contains("colCategoria"))
                dgvMovimientos.Columns["colCategoria"].DataPropertyName = "Categoria";

            if (dgvMovimientos.Columns.Contains("colMonto"))
            {
                dgvMovimientos.Columns["colMonto"].DataPropertyName = "Monto";
                dgvMovimientos.Columns["colMonto"].DefaultCellStyle.Format = "N0";
                dgvMovimientos.Columns["colMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMovimientos.Columns["colMonto"].FillWeight = 80;
            }

            if (dgvMovimientos.Columns.Contains("colFecha"))
            {
                dgvMovimientos.Columns["colFecha"].DataPropertyName = "Fecha";
                dgvMovimientos.Columns["colFecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMovimientos.Columns["colFecha"].FillWeight = 90;
            }

            if (dgvMovimientos.Columns.Contains("colMedioPago"))
            {
                dgvMovimientos.Columns["colMedioPago"].DataPropertyName = "MedioPago";
                dgvMovimientos.Columns["colMedioPago"].FillWeight = 90;
            }

            if (dgvMovimientos.Columns.Contains("colDescripcion"))
            {
                dgvMovimientos.Columns["colDescripcion"].DataPropertyName = "Descripcion";
                dgvMovimientos.Columns["colDescripcion"].FillWeight = 160;
            }

            // 👇 PREPARADO para mostrar usuario cuando agregues la columna al DGV
            if (dgvMovimientos.Columns.Contains("colCreadoPor"))
            {
                dgvMovimientos.Columns["colCreadoPor"].DataPropertyName = "CreadoPor";
                dgvMovimientos.Columns["colCreadoPor"].FillWeight = 90;
            }

            dgvMovimientos.ClearSelection();
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
        // VALIDACIONES
        // --------------------------
        private bool ValidarFormulario(out decimal monto)
        {
            monto = 0m;

            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("⚠ Seleccioná una categoría.");
                return false;
            }

            if (cboMedioPago.SelectedValue == null)
            {
                MessageBox.Show("⚠ Seleccioná un medio de pago.");
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out monto) || monto <= 0)
            {
                MessageBox.Show("⚠ Monto inválido (debe ser mayor a 0).");
                return false;
            }

            var desc = (txtDescripcion.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("⚠ Ingresá una descripción (ej: 'comida', 'uber', 'ropa').");
                return false;
            }

            return true;
        }

        // --------------------------
        // DATA: LISTAR (solo egresos libres)
        // --------------------------
        private async Task CargarEgresosEnGrillaAsync()
        {
            var lista = await _movimientosService.GetByTipoAsync("Egreso");

            var soloLibres = lista
                .Where(x => !(x.Descripcion ?? "").TrimStart().StartsWith("[FIJO]", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(x => x.Fecha)
                .ToList();

            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = soloLibres;
            dgvMovimientos.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            txtMonto.Clear();
            txtDescripcion.Clear();
            dtpFecha.Value = DateTime.Now;

            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            if (cboMedioPago.Items.Count > 0) cboMedioPago.SelectedIndex = 0;
        }

        // --------------------------
        // MODO EDICIÓN
        // --------------------------
        private void EntrarModoEdicion(int id)
        {
            _modoEdicion = true;
            _idEditando = id;
            btnAgregar.Text = "Actualizar";
        }

        private void SalirModoEdicion()
        {
            _modoEdicion = false;
            _idEditando = null;
            _creadoPorEditando = "";
            btnAgregar.Text = "Agregar";
        }

        // --------------------------
        // SELECCIÓN
        // --------------------------
        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PrecargarDesdeFila();
        }

        private void PrecargarDesdeFila()
        {
            if (dgvMovimientos.CurrentRow?.DataBoundItem is not MovimientoDto row)
                return;

            _idEditando = row.Id;
            _creadoPorEditando = row.CreadoPor ?? "";

            txtMonto.Text = row.Monto.ToString("0.##");
            txtDescripcion.Text = row.Descripcion ?? "";
            dtpFecha.Value = row.Fecha;

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
                if (string.Equals(current, (texto ?? "").Trim(), StringComparison.OrdinalIgnoreCase))
                    return;
            }
        }

        // --------------------------
        // EDITAR
        // --------------------------
        private void btnEditar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            if (dgvMovimientos.CurrentRow?.DataBoundItem is not MovimientoDto row)
            {
                MessageBox.Show("Seleccioná un gasto libre para editar.");
                return;
            }

            PrecargarDesdeFila();
            EntrarModoEdicion(row.Id);
        }

        // --------------------------
        // ELIMINAR
        // --------------------------
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            if (dgvMovimientos.CurrentRow?.DataBoundItem is not MovimientoDto row)
            {
                MessageBox.Show("Seleccioná un gasto libre para eliminar.");
                return;
            }

            var ok = MessageBox.Show(
                $"¿Eliminar este gasto?\n\n{row.Descripcion}",
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
                await CargarEgresosEnGrillaAsync();
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
                if (!ValidarFormulario(out var monto))
                    return;

                var creadoPor = _modoEdicion
                    ? (string.IsNullOrWhiteSpace(_creadoPorEditando) ? Session.Usuario : _creadoPorEditando)
                    : Session.Usuario;

                var dto = new CreateMovimientoDto
                {
                    Tipo = "Egreso",
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    MedioPagoId = (int)cboMedioPago.SelectedValue,
                    Monto = monto,
                    Fecha = dtpFecha.Value,
                    Descripcion = (txtDescripcion.Text ?? "").Trim(),
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
                await CargarEgresosEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }

        // --------------------------
        // CANCELAR
        // --------------------------
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