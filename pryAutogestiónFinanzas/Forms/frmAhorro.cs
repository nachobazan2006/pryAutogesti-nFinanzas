using pryAutogestiónFinanzas.Helpers;
using pryAutogestionFinanzas.Models;
using pryAutogestionFinanzas.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAutogestionFinanzas
{
    public partial class frmAhorros : Form
    {
        private readonly MetasAhorroService _metasService;
        private readonly BindingSource _bs = new BindingSource();

        private bool _modoEdicion = false;
        private int _idEditando = 0;
        private string _creadoPorEditando = "";

        public frmAhorros()
        {
            InitializeComponent();

            var api = new ApiClient();
            _metasService = new MetasAhorroService(api);

            // Evitar dobles enganches
            this.Load -= frmAhorros_Load;
            this.Load += frmAhorros_Load;

            btnAgregarMeta.Click -= btnAgregarMeta_Click;
            btnAgregarMeta.Click += btnAgregarMeta_Click;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        // --------------------------
        // LOAD
        // --------------------------
        private async void frmAhorros_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                dtpFechaObjetivo.Value = DateTime.Now;

                SalirModoEdicion();
                await CargarMetasEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error en Load:\n\n" + ex.ToString());
            }
        }

        // --------------------------
        // GRID
        // --------------------------
        private void ConfigurarGrilla()
        {
            dgvAhorro.AutoGenerateColumns = false;
            dgvAhorro.ReadOnly = true;
            dgvAhorro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAhorro.MultiSelect = false;
            dgvAhorro.AllowUserToAddRows = false;
            dgvAhorro.AllowUserToDeleteRows = false;
            dgvAhorro.AllowUserToResizeRows = false;
            dgvAhorro.RowHeadersVisible = false;

            dgvAhorro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAhorro.EnableHeadersVisualStyles = false;
            dgvAhorro.BorderStyle = BorderStyle.None;
            dgvAhorro.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAhorro.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvAhorro.BackgroundColor = Color.FromArgb(12, 18, 35);
            dgvAhorro.GridColor = Color.FromArgb(35, 45, 70);

            dgvAhorro.ColumnHeadersHeight = 40;
            dgvAhorro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 28, 52);
            dgvAhorro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAhorro.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAhorro.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvAhorro.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvAhorro.DefaultCellStyle.BackColor = Color.FromArgb(12, 18, 35);
            dgvAhorro.DefaultCellStyle.ForeColor = Color.FromArgb(230, 236, 255);
            dgvAhorro.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvAhorro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 90, 180);
            dgvAhorro.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAhorro.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvAhorro.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(14, 22, 42);

            dgvAhorro.DataSource = _bs;

            Map("colId", "Id", visible: false);
            Map("colNombre", "Nombre");
            Map("colObjetivo", "Objetivo");
            Map("colMoneda", "Moneda");
            Map("colLugarGuardado", "LugarGuardado");
            Map("colFechaObjetivo", "FechaObjetivo");
            Map("colCreadoPor", "CreadoPor");

            if (dgvAhorro.Columns.Contains("colObjetivo"))
            {
                var col = dgvAhorro.Columns["colObjetivo"];
                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.FillWeight = 90;
            }

            if (dgvAhorro.Columns.Contains("colFechaObjetivo"))
            {
                var col = dgvAhorro.Columns["colFechaObjetivo"];
                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.FillWeight = 90;
            }

            dgvAhorro.ClearSelection();
        }

        private void Map(string colName, string propName, bool? visible = null)
        {
            if (!dgvAhorro.Columns.Contains(colName)) return;

            dgvAhorro.Columns[colName].DataPropertyName = propName;
            if (visible.HasValue)
                dgvAhorro.Columns[colName].Visible = visible.Value;
        }

        // --------------------------
        // CARGAR METAS
        // --------------------------
        private async Task CargarMetasEnGrillaAsync()
        {
            var metas = await _metasService.GetAllAsync() ?? new List<MetaAhorroDto>();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Objetivo", typeof(decimal));
            dt.Columns.Add("Moneda", typeof(string));
            dt.Columns.Add("LugarGuardado", typeof(string));
            dt.Columns.Add("FechaObjetivo", typeof(DateTime));
            dt.Columns.Add("CreadoPor", typeof(string));

            foreach (var m in metas.OrderByDescending(x => x.Id))
            {
                var fecha = m.FechaObjetivo ?? DateTime.Now;

                dt.Rows.Add(
                    m.Id,
                    (m.Nombre ?? "").Trim(),
                    m.Objetivo,
                    (m.Moneda ?? "").Trim(),
                    (m.LugarGuardado ?? "").Trim(),
                    fecha,
                    (m.CreadoPor ?? "").Trim()
                );
            }

            _bs.DataSource = dt;
            dgvAhorro.ClearSelection();
        }

        // --------------------------
        // AGREGAR / ACTUALIZAR
        // --------------------------
        private async void btnAgregarMeta_Click(object sender, EventArgs e)
        {
            try
            {
                var nombre = (txtNombreMeta.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Completá el nombre de la meta.");
                    txtNombreMeta.Focus();
                    return;
                }

                if (!TryParseDecimal(txtObjetivo.Text, out var objetivo) || objetivo <= 0)
                {
                    MessageBox.Show("Objetivo inválido (debe ser mayor a 0).");
                    txtObjetivo.Focus();
                    return;
                }

                var moneda = (txtMoneda.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(moneda))
                {
                    MessageBox.Show("Completá la moneda (ej: ARS, USD).");
                    txtMoneda.Focus();
                    return;
                }

                var lugar = (txtLugarGuardado.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(lugar))
                {
                    MessageBox.Show("Completá el lugar guardado.");
                    txtLugarGuardado.Focus();
                    return;
                }

                var creadoPor = _modoEdicion
                    ? (string.IsNullOrWhiteSpace(_creadoPorEditando) ? Session.Usuario : _creadoPorEditando)
                    : Session.Usuario;

                var dto = new MetaAhorroDto
                {
                    Id = _modoEdicion ? _idEditando : 0,
                    Nombre = nombre,
                    Objetivo = objetivo,
                    Moneda = moneda,
                    LugarGuardado = lugar,
                    FechaObjetivo = dtpFechaObjetivo.Value,
                    CreadoPor = creadoPor
                };

                if (!_modoEdicion)
                {
                    await _metasService.CreateAsync(dto);
                    MessageBox.Show("✅ Meta guardada.");
                }
                else
                {
                    await _metasService.UpdateAsync(_idEditando, dto);
                    MessageBox.Show("✅ Meta actualizada.");
                    SalirModoEdicion();
                }

                LimpiarFormulario();
                await CargarMetasEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error:\n\n" + ex.ToString());
            }
        }

        // --------------------------
        // EDITAR
        // --------------------------
        private void btnEditar_Click(object sender, EventArgs e)
        {
            var (ok, id, nombre, objetivo, moneda, lugar, fechaObj, creadoPor) = LeerFilaSeleccionada();
            if (!ok)
            {
                MessageBox.Show("Seleccioná una meta para editar.");
                return;
            }

            _modoEdicion = true;
            _idEditando = id;
            _creadoPorEditando = creadoPor;

            txtNombreMeta.Text = nombre;
            txtObjetivo.Text = objetivo.ToString("0.##", CultureInfo.CurrentCulture);
            txtMoneda.Text = moneda;
            txtLugarGuardado.Text = lugar;
            dtpFechaObjetivo.Value = fechaObj;

            btnAgregarMeta.Text = "Actualizar";
            btnCancelar.Enabled = true;
        }

        // --------------------------
        // ELIMINAR
        // --------------------------
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var (ok, id, nombre, _, _, _, _, _) = LeerFilaSeleccionada();
            if (!ok)
            {
                MessageBox.Show("Seleccioná una meta para eliminar.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar la meta '{nombre}'?\n\nSe eliminarán también sus aportes.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                await _metasService.DeleteAsync(id);
                MessageBox.Show("✅ Meta eliminada.");

                SalirModoEdicion();
                LimpiarFormulario();
                await CargarMetasEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error:\n\n" + ex.ToString());
            }
        }

        // --------------------------
        // CANCELAR EDICIÓN
        // --------------------------
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            SalirModoEdicion();
            LimpiarFormulario();
            dgvAhorro.ClearSelection();
            await CargarMetasEnGrillaAsync();
        }

        private void SalirModoEdicion()
        {
            _modoEdicion = false;
            _idEditando = 0;
            _creadoPorEditando = "";

            btnAgregarMeta.Text = "Agregar meta";
            btnCancelar.Enabled = false;
        }

        private void LimpiarFormulario()
        {
            txtNombreMeta.Clear();
            txtObjetivo.Clear();
            txtMoneda.Clear();
            txtLugarGuardado.Clear();
            dtpFechaObjetivo.Value = DateTime.Now;
        }

        // --------------------------
        // Helpers selección
        // --------------------------
        private (bool ok, int id, string nombre, decimal objetivo, string moneda, string lugar, DateTime fechaObjetivo, string creadoPor) LeerFilaSeleccionada()
        {
            try
            {
                if (dgvAhorro.CurrentRow == null)
                    return (false, 0, "", 0m, "", "", DateTime.Now, "");

                var id = Convert.ToInt32(dgvAhorro.CurrentRow.Cells["colId"].Value);
                var nombre = Convert.ToString(dgvAhorro.CurrentRow.Cells["colNombre"].Value) ?? "";
                var objetivo = Convert.ToDecimal(dgvAhorro.CurrentRow.Cells["colObjetivo"].Value);
                var moneda = Convert.ToString(dgvAhorro.CurrentRow.Cells["colMoneda"].Value) ?? "";
                var lugar = Convert.ToString(dgvAhorro.CurrentRow.Cells["colLugarGuardado"].Value) ?? "";
                var fecha = Convert.ToDateTime(dgvAhorro.CurrentRow.Cells["colFechaObjetivo"].Value);

                string creadoPor = "";
                if (dgvAhorro.Columns.Contains("colCreadoPor"))
                    creadoPor = Convert.ToString(dgvAhorro.CurrentRow.Cells["colCreadoPor"].Value) ?? "";

                return (true, id, nombre, objetivo, moneda, lugar, fecha, creadoPor);
            }
            catch
            {
                return (false, 0, "", 0m, "", "", DateTime.Now, "");
            }
        }

        private bool TryParseDecimal(string? input, out decimal value)
        {
            value = 0m;
            var s = (input ?? "").Trim();
            if (string.IsNullOrWhiteSpace(s)) return false;

            return decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out value)
                || decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }
    }
}