using pryAutogestionFinanzas.Models;
using pryAutogestionFinanzas.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAutogestionFinanzas
{
    public partial class frmIngresos : Form
    {
        private readonly CatalogosService _catalogosService;
        private readonly MovimientosService _movimientosService;

        private readonly BindingSource _bs = new BindingSource();

        // Modo edición
        private bool _modoEdicion = false;
        private int? _idEditando = null;

        public frmIngresos()
        {
            InitializeComponent();

            var api = new ApiClient();
            _catalogosService = new CatalogosService(api);
            _movimientosService = new MovimientosService(api);

            // Eventos (evita dobles enganches)
            this.Load -= frmIngresos_Load;
            this.Load += frmIngresos_Load;

            btnAgregar.Click -= btnAgregar_Click;
            btnAgregar.Click += btnAgregar_Click;

            // Si los agregaste recién en UI, los engancho acá igual:
            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;

            dgvMovimientos.CellClick -= dgvMovimientos_CellClick;
            dgvMovimientos.CellClick += dgvMovimientos_CellClick;
        }

        // --------------------------
        // LOAD
        // --------------------------
        private async void frmIngresos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                await CargarCatalogosAsync();

                dtpFecha.Value = DateTime.Now;

                await CargarIngresosEnGrillaAsync();
                SalirModoEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error en Load: " + ex.Message);
            }
        }

        // --------------------------
        // CARGAR CAT + MEDIOS
        // --------------------------
        private async Task CargarCatalogosAsync()
        {
            var data = await _catalogosService.GetCatalogosAsync();

            var catIngreso = data.Categorias
                .Where(c => (c.Tipo ?? "").Trim().Equals("Ingreso", StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Nombre)
                .ToList();

            cboCategoria.DataSource = catIngreso;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedIndex = catIngreso.Count > 0 ? 0 : -1;

            var medios = data.MediosPago.OrderBy(m => m.Nombre).ToList();
            cboMedioPago.DataSource = medios;
            cboMedioPago.DisplayMember = "Nombre";
            cboMedioPago.ValueMember = "Id";
            cboMedioPago.SelectedIndex = medios.Count > 0 ? 0 : -1;
        }

        // --------------------------
        // GRID
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

            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMovimientos.GridColor = Color.FromArgb(35, 45, 70);
            dgvMovimientos.BackgroundColor = Color.FromArgb(12, 18, 35);

            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMovimientos.ColumnHeadersHeight = 40;

            dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 28, 52);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvMovimientos.DefaultCellStyle.BackColor = Color.FromArgb(12, 18, 35);
            dgvMovimientos.DefaultCellStyle.ForeColor = Color.FromArgb(230, 236, 255);
            dgvMovimientos.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvMovimientos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 90, 180);
            dgvMovimientos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMovimientos.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(14, 22, 42);

            // ✅ binding
            dgvMovimientos.DataSource = _bs;

            // Mapeo a IngresoGridRow
            SetMap("colId", nameof(IngresoGridRow.Id));
            SetMap("colFuenteIngreso", nameof(IngresoGridRow.FuenteIngreso));
            SetMap("colCategoria", nameof(IngresoGridRow.Categoria));
            SetMap("colMonto", nameof(IngresoGridRow.Monto));
            SetMap("colFecha", nameof(IngresoGridRow.Fecha));
            SetMap("colMedioPago", nameof(IngresoGridRow.MedioPago));
            SetMap("colNotas", nameof(IngresoGridRow.Notas));

            // colId oculta (recomendado)
            if (dgvMovimientos.Columns.Contains("colId"))
                dgvMovimientos.Columns["colId"].Visible = false;

            // Formatos
            if (dgvMovimientos.Columns.Contains("colMonto"))
            {
                var col = dgvMovimientos.Columns["colMonto"];
                col.DefaultCellStyle.Format = "N0";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.DefaultCellStyle.Padding = new Padding(0, 0, 12, 0);
            }

            if (dgvMovimientos.Columns.Contains("colFecha"))
            {
                var col = dgvMovimientos.Columns["colFecha"];
                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            // Pesos (compacto)
            SetWidth("colFuenteIngreso", 120);
            SetWidth("colCategoria", 85);
            SetWidth("colMonto", 75);
            SetWidth("colFecha", 85);
            SetWidth("colMedioPago", 95);
            SetWidth("colNotas", 140);

            dgvMovimientos.ClearSelection();
        }

        private void SetWidth(string colName, int weight)
        {
            if (dgvMovimientos.Columns.Contains(colName))
                dgvMovimientos.Columns[colName].FillWeight = weight;
        }

        private void SetMap(string colName, string propName)
        {
            if (dgvMovimientos.Columns.Contains(colName))
                dgvMovimientos.Columns[colName].DataPropertyName = propName;
        }

        // --------------------------
        // CARGAR INGRESOS
        // --------------------------
        private async Task CargarIngresosEnGrillaAsync()
        {
            var lista = await _movimientosService.GetByTipoAsync("Ingreso");

            var rows = lista
                .OrderByDescending(x => x.Fecha)
                .Select(x =>
                {
                    SplitDescripcion(x.Descripcion, out var fuente, out var notas);

                    return new IngresoGridRow
                    {
                        Id = x.Id,
                        FuenteIngreso = fuente,
                        Categoria = x.Categoria ?? "",
                        Monto = x.Monto,
                        Fecha = x.Fecha,
                        MedioPago = x.MedioPago ?? "",
                        Notas = notas
                    };
                })
                .ToList();

            _bs.DataSource = rows;
            dgvMovimientos.ClearSelection();
        }

        // --------------------------
        // SELECCIÓN -> PRECARGA
        // --------------------------
        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PrecargarDesdeFila();
        }

        private void PrecargarDesdeFila()
        {
            if (dgvMovimientos.CurrentRow?.DataBoundItem is not IngresoGridRow row)
                return;

            _idEditando = row.Id;

            txtFuenteIngreso.Text = row.FuenteIngreso;
            txtMonto.Text = row.Monto.ToString("0.##");
            txtNotas.Text = row.Notas;
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
            btnAgregar.Text = "Agregar";
        }

        // --------------------------
        // EDITAR
        // --------------------------
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientos.CurrentRow?.DataBoundItem is not IngresoGridRow row)
            {
                MessageBox.Show("Seleccioná un ingreso para editar.");
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
            if (dgvMovimientos.CurrentRow?.DataBoundItem is not IngresoGridRow row)
            {
                MessageBox.Show("Seleccioná un ingreso para eliminar.");
                return;
            }

            var ok = MessageBox.Show(
                $"¿Eliminar este ingreso?\n\n{row.FuenteIngreso} - {row.Monto:N0}",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (ok != DialogResult.Yes) return;

            try
            {
                await _movimientosService.DeleteAsync(row.Id);

                MessageBox.Show("✅ Eliminado.");

                LimpiarForm();
                SalirModoEdicion();
                await CargarIngresosEnGrillaAsync();
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
            try
            {
                // Validaciones: todo obligatorio salvo notas
                var fuente = (txtFuenteIngreso.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(fuente))
                {
                    MessageBox.Show("Completá la fuente de ingreso.");
                    txtFuenteIngreso.Focus();
                    return;
                }

                if (cboCategoria.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná una categoría.");
                    cboCategoria.Focus();
                    return;
                }

                if (cboMedioPago.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná un medio de pago.");
                    cboMedioPago.Focus();
                    return;
                }

                if (!decimal.TryParse(txtMonto.Text, out var monto) || monto <= 0)
                {
                    MessageBox.Show("Ingresá un monto válido (> 0).");
                    txtMonto.Focus();
                    return;
                }

                var fecha = dtpFecha.Value;
                var notas = (txtNotas.Text ?? "").Trim();

                var descripcion = fuente + (string.IsNullOrWhiteSpace(notas) ? "" : $" | Notas: {notas}");

                var dto = new CreateMovimientoDto
                {
                    Tipo = "Ingreso",
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    MedioPagoId = (int)cboMedioPago.SelectedValue,
                    Monto = monto,
                    Fecha = fecha,
                    Descripcion = descripcion
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
                    MessageBox.Show("✅ Ingreso guardado.");
                }

                LimpiarForm();
                SalirModoEdicion();
                await CargarIngresosEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }

        private void LimpiarForm()
        {
            txtFuenteIngreso.Clear();
            txtMonto.Clear();
            txtNotas.Clear();
            dtpFecha.Value = DateTime.Now;

            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            if (cboMedioPago.Items.Count > 0) cboMedioPago.SelectedIndex = 0;
        }

        // --------------------------
        // PARSEO: "Fuente | Notas: ..."
        // --------------------------
        private void SplitDescripcion(string? descripcion, out string fuente, out string notas)
        {
            fuente = "";
            notas = "";

            var d = (descripcion ?? "").Trim();
            if (string.IsNullOrWhiteSpace(d))
                return;

            var parts = d.Split(new[] { "| Notas:" }, StringSplitOptions.None);

            fuente = parts[0].Trim();
            if (parts.Length > 1)
                notas = parts[1].Trim();
        }

        // --------------------------
        // VIEW MODEL (para grilla)
        // --------------------------
        private class IngresoGridRow
        {
            public int Id { get; set; }
            public string FuenteIngreso { get; set; } = "";
            public string Categoria { get; set; } = "";
            public decimal Monto { get; set; }
            public DateTime Fecha { get; set; }
            public string MedioPago { get; set; } = "";
            public string Notas { get; set; } = "";
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // Salir edición + limpiar UI
                SalirModoEdicion();
                LimpiarForm(); // en ingresos es LimpiarForm()

                // Limpia selección de grilla
                dgvMovimientos.ClearSelection();

                // (Opcional) recargar para dejar todo consistente
                // GastosLibres: await CargarEgresosEnGrillaAsync();
                // GastosFijos:  await CargarFijosEnGrillaAsync();
                // Ingresos:     await CargarIngresosEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar: " + ex.Message);
            }
        }
    }
}