using Guna.UI2.WinForms;
using pryAutogestionFinanzas.Models;
using pryAutogestionFinanzas.Services;
using pryAutogestiónFinanzas.Helpers;
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
    public partial class frmAporte : Form
    {
        private readonly ApiClient _api;
        private readonly BindingSource _bs = new BindingSource();

        private bool _modoEdicion = false;
        private int _idEditando = 0;

        public frmAporte()
        {
            InitializeComponent();

            _api = new ApiClient();

            this.Load -= frmAporte_Load;
            this.Load += frmAporte_Load;

            btnAgregarAporte.Click -= btnAgregarAporte_Click;
            btnAgregarAporte.Click += btnAgregarAporte_Click;

            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnCancelarEdicion.Click -= btnCancelarEdicion_Click;
            btnCancelarEdicion.Click += btnCancelarEdicion_Click;

           

            cboMeta.SelectedIndexChanged += cboMeta_SelectedIndexChanged;
        }

        // --------------------------
        // LOAD
        // --------------------------
        private async void frmAporte_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();

                await CargarMetasAsync();
                dtpFecha.Value = DateTime.Now;

                SalirModoEdicion();
                await CargarAportesEnGrillaAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error en Load:\n\n" + ex.ToString());
            }
        }

        // --------------------------
        // CARGAR METAS
        // --------------------------
        private async Task CargarMetasAsync()
        {
            var metas = await _api.GetAsync<List<MetaAhorroDto>>("MetasAhorro") ?? new List<MetaAhorroDto>();

            cboMeta.DataSource = metas;
            cboMeta.DisplayMember = nameof(MetaAhorroDto.Nombre);
            cboMeta.ValueMember = nameof(MetaAhorroDto.Id);
            cboMeta.SelectedIndex = metas.Count > 0 ? 0 : -1;
        }

        private async void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.SelectedValue != null)
                await CargarAportesEnGrillaAsync();
        }

        // --------------------------
        // CARGAR APORTES
        // --------------------------
        private async Task CargarAportesEnGrillaAsync()
        {
            if (cboMeta.SelectedValue == null)
                return;

            if (cboMeta.SelectedValue is not int metaId)
            {
                if (!int.TryParse(cboMeta.SelectedValue.ToString(), out metaId))
                    return;
            }

            var aportes = await _api.GetAsync<List<AporteAhorroDto>>($"AportesAhorro/ByMeta/{metaId}")
                         ?? new List<AporteAhorroDto>();

            var metas = cboMeta.DataSource as List<MetaAhorroDto> ?? new List<MetaAhorroDto>();
            var mapMetas = metas.ToDictionary(m => m.Id, m => m.Nombre);

            var dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("MetaAhorroId", typeof(int));
            dt.Columns.Add("Meta", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Monto", typeof(decimal));
            dt.Columns.Add("Notas", typeof(string));
            dt.Columns.Add("CreadoPor", typeof(string));

            foreach (var a in aportes.OrderByDescending(x => x.Fecha))
            {
                var metaNombre = mapMetas.TryGetValue(a.MetaAhorroId, out var nombre)
                    ? nombre
                    : $"Meta #{a.MetaAhorroId}";

                dt.Rows.Add(
                    a.Id,
                    a.MetaAhorroId,
                    metaNombre,
                    a.Fecha,
                    a.Monto,
                    a.Notas ?? "",
                    a.CreadoPor ?? ""
                );
            }

            _bs.DataSource = dt;
            dgvAportes.DataSource = _bs;
            dgvAportes.ClearSelection();
        }

        // --------------------------
        // GRID
        // --------------------------
        private void ConfigurarGrilla()
        {
            dgvAportes.AutoGenerateColumns = false;
            dgvAportes.ReadOnly = true;
            dgvAportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAportes.MultiSelect = false;
            dgvAportes.AllowUserToAddRows = false;
            dgvAportes.AllowUserToDeleteRows = false;
            dgvAportes.AllowUserToResizeRows = false;
            dgvAportes.RowHeadersVisible = false;

            dgvAportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAportes.EnableHeadersVisualStyles = false;
            dgvAportes.BorderStyle = BorderStyle.None;
            dgvAportes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAportes.BackgroundColor = Color.FromArgb(12, 18, 35);
            dgvAportes.GridColor = Color.FromArgb(35, 45, 70);

            dgvAportes.ColumnHeadersHeight = 40;
            dgvAportes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 28, 52);
            dgvAportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAportes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvAportes.DefaultCellStyle.BackColor = Color.FromArgb(12, 18, 35);
            dgvAportes.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgvAportes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 90, 180);
            dgvAportes.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvAportes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(14, 22, 42);

            Map("colId", "Id", false);
            Map("colMetaAhorroId", "MetaAhorroId", false);
            Map("colMeta", "Meta");
            Map("colFecha", "Fecha");
            Map("colMonto", "Monto");
            Map("colNotas", "Notas");
            Map("colCreadoPor", "CreadoPor");

            if (dgvAportes.Columns.Contains("colFecha"))
                dgvAportes.Columns["colFecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvAportes.Columns.Contains("colMonto"))
                dgvAportes.Columns["colMonto"].DefaultCellStyle.Format = "N2";
        }

        private void Map(string colName, string propName, bool visible = true)
        {
            if (!dgvAportes.Columns.Contains(colName)) return;

            dgvAportes.Columns[colName].DataPropertyName = propName;
            dgvAportes.Columns[colName].Visible = visible;
        }

        // --------------------------
        // CREATE / UPDATE
        // --------------------------
        private async void btnAgregarAporte_Click(object sender, EventArgs e)
        {
            SetActiveButton((Guna2Button)sender);

            try
            {
                if (cboMeta.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná una meta.");
                    return;
                }

                if (!TryParseDecimal(txtMonto.Text, out var monto) || monto <= 0)
                {
                    MessageBox.Show("Monto inválido.");
                    return;
                }

                var dto = new AporteAhorroDto
                {
                    Id = _modoEdicion ? _idEditando : 0,
                    MetaAhorroId = (int)cboMeta.SelectedValue,
                    Fecha = dtpFecha.Value,
                    Monto = monto,
                    Notas = string.IsNullOrWhiteSpace(txtNotas.Text) ? null : txtNotas.Text.Trim(),
                    CreadoPor = Session.Usuario
                };

                if (!_modoEdicion)
                {
                    await _api.PostAsync<AporteAhorroDto>("AportesAhorro", dto);
                    MessageBox.Show("✅ Aporte guardado.");
                }
                else
                {
                    await _api.PutAsync($"AportesAhorro/{_idEditando}", dto);
                    MessageBox.Show("✅ Aporte actualizado.");
                    SalirModoEdicion();
                }

                LimpiarFormulario();
                await CargarAportesEnGrillaAsync();
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
            var (ok, id, metaId, fecha, monto, notas) = LeerFilaSeleccionada();
            if (!ok)
            {
                MessageBox.Show("Seleccioná un aporte.");
                return;
            }

            _modoEdicion = true;
            _idEditando = id;

            cboMeta.SelectedValue = metaId;
            dtpFecha.Value = fecha;
            txtMonto.Text = monto.ToString("0.##");
            txtNotas.Text = notas ?? "";

            btnAgregarAporte.Text = "Actualizar";
            btnCancelarEdicion.Visible = true;
        }

        // --------------------------
        // ELIMINAR
        // --------------------------
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var (ok, id, _, _, _, _) = LeerFilaSeleccionada();

            if (!ok)
            {
                MessageBox.Show("Seleccioná un aporte.");
                return;
            }

            var confirm = MessageBox.Show("¿Eliminar aporte?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes) return;

            await _api.DeleteAsync($"AportesAhorro/{id}");

            MessageBox.Show("✅ Eliminado");

            await CargarAportesEnGrillaAsync();
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            SalirModoEdicion();
            LimpiarFormulario();
        }

        // --------------------------
        // Helpers
        // --------------------------
        private (bool ok, int id, int metaId, DateTime fecha, decimal monto, string? notas) LeerFilaSeleccionada()
        {
            try
            {
                if (dgvAportes.CurrentRow == null) return (false, 0, 0, DateTime.Now, 0m, null);

                return (
                    true,
                    Convert.ToInt32(dgvAportes.CurrentRow.Cells["colId"].Value),
                    Convert.ToInt32(dgvAportes.CurrentRow.Cells["colMetaAhorroId"].Value),
                    Convert.ToDateTime(dgvAportes.CurrentRow.Cells["colFecha"].Value),
                    Convert.ToDecimal(dgvAportes.CurrentRow.Cells["colMonto"].Value),
                    Convert.ToString(dgvAportes.CurrentRow.Cells["colNotas"].Value)
                );
            }
            catch
            {
                return (false, 0, 0, DateTime.Now, 0m, null);
            }
        }

        private void SalirModoEdicion()
        {
            _modoEdicion = false;
            _idEditando = 0;

            btnAgregarAporte.Text = "Agregar aporte";
            btnCancelarEdicion.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtMonto.Clear();
            txtNotas.Clear();
            dtpFecha.Value = DateTime.Now;
        }

        private void SetActiveButton(Guna2Button btn)
        {
            foreach (Control c in panelLateral.Controls)
                if (c is Guna2Button b)
                    b.FillColor = Color.FromArgb(52, 72, 97);

            btn.FillColor = Color.FromArgb(113, 99, 199);
        }

        private bool TryParseDecimal(string? input, out decimal value)
        {
            value = 0m;

            return decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out value)
                || decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }
    }
}