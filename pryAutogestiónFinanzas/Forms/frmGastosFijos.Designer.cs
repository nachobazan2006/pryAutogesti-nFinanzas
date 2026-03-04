namespace pryAutogestionFinanzas
{
    partial class frmGastosFijos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitulo = new Label();
            panelLateral = new Panel();
            dtpVencimiento = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            txtNotas = new Guna.UI2.WinForms.Guna2TextBox();
            lblNotas = new Label();
            lblMedioPago = new Label();
            lblNombreDelGasto = new Label();
            lblVencimiento = new Label();
            cboMedioPago = new Guna.UI2.WinForms.Guna2ComboBox();
            lblMonto = new Label();
            lblCategoria = new Label();
            txtMonto = new Guna.UI2.WinForms.Guna2TextBox();
            cboCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            txtNombreGasto = new Guna.UI2.WinForms.Guna2TextBox();
            dgvMovimientos = new Guna.UI2.WinForms.Guna2DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombreGasto = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colVencimiento = new DataGridViewTextBoxColumn();
            colMedioPago = new DataGridViewTextBoxColumn();
            colNotas = new DataGridViewTextBoxColumn();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelarEdicion = new Guna.UI2.WinForms.Guna2Button();
            panelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.Window;
            lblTitulo.Location = new Point(32, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(235, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregue gasto";
            // 
            // panelLateral
            // 
            panelLateral.BackColor = Color.FromArgb(0, 0, 64);
            panelLateral.Controls.Add(dtpVencimiento);
            panelLateral.Controls.Add(btnAgregar);
            panelLateral.Controls.Add(txtNotas);
            panelLateral.Controls.Add(lblNotas);
            panelLateral.Controls.Add(lblMedioPago);
            panelLateral.Controls.Add(lblNombreDelGasto);
            panelLateral.Controls.Add(lblVencimiento);
            panelLateral.Controls.Add(cboMedioPago);
            panelLateral.Controls.Add(lblMonto);
            panelLateral.Controls.Add(lblCategoria);
            panelLateral.Controls.Add(txtMonto);
            panelLateral.Controls.Add(cboCategoria);
            panelLateral.Controls.Add(txtNombreGasto);
            panelLateral.Controls.Add(lblTitulo);
            panelLateral.Location = new Point(-3, -5);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(280, 901);
            panelLateral.TabIndex = 1;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Checked = true;
            dtpVencimiento.CustomizableEdges = customizableEdges1;
            dtpVencimiento.Font = new Font("Segoe UI", 9F);
            dtpVencimiento.Format = DateTimePickerFormat.Long;
            dtpVencimiento.Location = new Point(15, 460);
            dtpVencimiento.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpVencimiento.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpVencimiento.Size = new Size(252, 36);
            dtpVencimiento.TabIndex = 3;
            dtpVencimiento.Value = new DateTime(2026, 3, 2, 16, 44, 51, 45);
            // 
            // btnAgregar
            // 
            btnAgregar.Animated = true;
            btnAgregar.BorderRadius = 10;
            btnAgregar.CustomizableEdges = customizableEdges3;
            btnAgregar.DisabledState.BorderColor = Color.DarkGray;
            btnAgregar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAgregar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAgregar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAgregar.FillColor = Color.DarkGray;
            btnAgregar.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            btnAgregar.Location = new Point(15, 787);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAgregar.Size = new Size(252, 51);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtNotas
            // 
            txtNotas.BorderRadius = 10;
            txtNotas.CustomizableEdges = customizableEdges5;
            txtNotas.DefaultText = "";
            txtNotas.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNotas.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNotas.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNotas.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNotas.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNotas.Font = new Font("Segoe UI", 9F);
            txtNotas.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNotas.Location = new Point(15, 675);
            txtNotas.Margin = new Padding(3, 4, 3, 4);
            txtNotas.Name = "txtNotas";
            txtNotas.PlaceholderText = "";
            txtNotas.SelectedText = "";
            txtNotas.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNotas.Size = new Size(252, 72);
            txtNotas.TabIndex = 3;
            // 
            // lblNotas
            // 
            lblNotas.AutoSize = true;
            lblNotas.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNotas.ForeColor = SystemColors.Window;
            lblNotas.Location = new Point(15, 635);
            lblNotas.Name = "lblNotas";
            lblNotas.Size = new Size(68, 23);
            lblNotas.TabIndex = 3;
            lblNotas.Text = "Notas";
            // 
            // lblMedioPago
            // 
            lblMedioPago.AutoSize = true;
            lblMedioPago.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMedioPago.ForeColor = SystemColors.Window;
            lblMedioPago.Location = new Point(15, 537);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(165, 23);
            lblMedioPago.TabIndex = 7;
            lblMedioPago.Text = "Medio de pago";
            // 
            // lblNombreDelGasto
            // 
            lblNombreDelGasto.AutoSize = true;
            lblNombreDelGasto.BackColor = Color.FromArgb(0, 0, 64);
            lblNombreDelGasto.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNombreDelGasto.ForeColor = Color.Cornsilk;
            lblNombreDelGasto.Location = new Point(15, 97);
            lblNombreDelGasto.Name = "lblNombreDelGasto";
            lblNombreDelGasto.Size = new Size(169, 21);
            lblNombreDelGasto.TabIndex = 3;
            lblNombreDelGasto.Text = "Nombre del gasto";
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVencimiento.ForeColor = SystemColors.Window;
            lblVencimiento.Location = new Point(15, 419);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(186, 21);
            lblVencimiento.TabIndex = 6;
            lblVencimiento.Text = "Día de vencimiento";
            // 
            // cboMedioPago
            // 
            cboMedioPago.BackColor = Color.Transparent;
            cboMedioPago.BorderRadius = 10;
            cboMedioPago.CustomizableEdges = customizableEdges7;
            cboMedioPago.DrawMode = DrawMode.OwnerDrawFixed;
            cboMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedioPago.FocusedColor = Color.FromArgb(94, 148, 255);
            cboMedioPago.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboMedioPago.Font = new Font("Segoe UI", 10F);
            cboMedioPago.ForeColor = Color.FromArgb(68, 88, 112);
            cboMedioPago.ItemHeight = 30;
            cboMedioPago.Location = new Point(15, 581);
            cboMedioPago.Name = "cboMedioPago";
            cboMedioPago.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cboMedioPago.Size = new Size(252, 36);
            cboMedioPago.TabIndex = 3;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMonto.ForeColor = SystemColors.Window;
            lblMonto.Location = new Point(15, 283);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(71, 21);
            lblMonto.TabIndex = 4;
            lblMonto.Text = "Monto";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCategoria.ForeColor = SystemColors.Window;
            lblCategoria.Location = new Point(15, 183);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(101, 21);
            lblCategoria.TabIndex = 3;
            lblCategoria.Text = "Categoría";
            // 
            // txtMonto
            // 
            txtMonto.BorderRadius = 10;
            txtMonto.CustomizableEdges = customizableEdges9;
            txtMonto.DefaultText = "";
            txtMonto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMonto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMonto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMonto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMonto.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMonto.Font = new Font("Segoe UI", 9F);
            txtMonto.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMonto.Location = new Point(15, 322);
            txtMonto.Margin = new Padding(3, 4, 3, 4);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "";
            txtMonto.SelectedText = "";
            txtMonto.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtMonto.Size = new Size(252, 25);
            txtMonto.TabIndex = 3;
            // 
            // cboCategoria
            // 
            cboCategoria.BackColor = Color.Transparent;
            cboCategoria.BorderRadius = 10;
            cboCategoria.CustomizableEdges = customizableEdges11;
            cboCategoria.DrawMode = DrawMode.OwnerDrawFixed;
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FocusedColor = Color.FromArgb(94, 148, 255);
            cboCategoria.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboCategoria.Font = new Font("Segoe UI", 10F);
            cboCategoria.ForeColor = Color.FromArgb(68, 88, 112);
            cboCategoria.ItemHeight = 30;
            cboCategoria.Location = new Point(15, 219);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cboCategoria.Size = new Size(252, 36);
            cboCategoria.TabIndex = 3;
            // 
            // txtNombreGasto
            // 
            txtNombreGasto.BorderRadius = 10;
            txtNombreGasto.CustomizableEdges = customizableEdges13;
            txtNombreGasto.DefaultText = "";
            txtNombreGasto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNombreGasto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNombreGasto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNombreGasto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNombreGasto.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNombreGasto.Font = new Font("Segoe UI", 9F);
            txtNombreGasto.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNombreGasto.Location = new Point(15, 137);
            txtNombreGasto.Margin = new Padding(3, 4, 3, 4);
            txtNombreGasto.Name = "txtNombreGasto";
            txtNombreGasto.PlaceholderText = "";
            txtNombreGasto.SelectedText = "";
            txtNombreGasto.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtNombreGasto.Size = new Size(252, 25);
            txtNombreGasto.TabIndex = 3;
            // 
            // dgvMovimientos
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvMovimientos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMovimientos.ColumnHeadersHeight = 4;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombreGasto, colCategoria, colMonto, colVencimiento, colMedioPago, colNotas });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMovimientos.GridColor = Color.FromArgb(231, 229, 255);
            dgvMovimientos.Location = new Point(423, 146);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.Size = new Size(735, 596);
            dgvMovimientos.TabIndex = 2;
            dgvMovimientos.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvMovimientos.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvMovimientos.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvMovimientos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvMovimientos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvMovimientos.ThemeStyle.BackColor = Color.White;
            dgvMovimientos.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvMovimientos.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvMovimientos.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMovimientos.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvMovimientos.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvMovimientos.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMovimientos.ThemeStyle.HeaderStyle.Height = 4;
            dgvMovimientos.ThemeStyle.ReadOnly = false;
            dgvMovimientos.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvMovimientos.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMovimientos.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvMovimientos.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvMovimientos.ThemeStyle.RowsStyle.Height = 29;
            dgvMovimientos.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvMovimientos.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colNombreGasto
            // 
            colNombreGasto.HeaderText = "Nombre del gasto";
            colNombreGasto.MinimumWidth = 6;
            colNombreGasto.Name = "colNombreGasto";
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            // 
            // colMonto
            // 
            colMonto.HeaderText = "Monto";
            colMonto.MinimumWidth = 6;
            colMonto.Name = "colMonto";
            // 
            // colVencimiento
            // 
            colVencimiento.HeaderText = "Vencimiento";
            colVencimiento.MinimumWidth = 6;
            colVencimiento.Name = "colVencimiento";
            // 
            // colMedioPago
            // 
            colMedioPago.HeaderText = "Medio de pago";
            colMedioPago.MinimumWidth = 6;
            colMedioPago.Name = "colMedioPago";
            // 
            // colNotas
            // 
            colNotas.HeaderText = "Notas";
            colNotas.MinimumWidth = 6;
            colNotas.Name = "colNotas";
            // 
            // btnEditar
            // 
            btnEditar.CustomizableEdges = customizableEdges15;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(370, 65);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnEditar.Size = new Size(225, 56);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            // 
            // btnEliminar
            // 
            btnEliminar.CustomizableEdges = customizableEdges17;
            btnEliminar.DisabledState.BorderColor = Color.DarkGray;
            btnEliminar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEliminar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEliminar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEliminar.Font = new Font("Segoe UI", 9F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(732, 75);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnEliminar.Size = new Size(225, 56);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            // 
            // btnCancelarEdicion
            // 
            btnCancelarEdicion.CustomizableEdges = customizableEdges19;
            btnCancelarEdicion.DisabledState.BorderColor = Color.DarkGray;
            btnCancelarEdicion.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelarEdicion.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelarEdicion.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelarEdicion.Font = new Font("Segoe UI", 9F);
            btnCancelarEdicion.ForeColor = Color.White;
            btnCancelarEdicion.Location = new Point(1049, 65);
            btnCancelarEdicion.Name = "btnCancelarEdicion";
            btnCancelarEdicion.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnCancelarEdicion.Size = new Size(225, 56);
            btnCancelarEdicion.TabIndex = 5;
            btnCancelarEdicion.Text = "Cancelar edición";
            btnCancelarEdicion.Click += btnCancelar_Click;
            // 
            // frmGastosFijos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 868);
            Controls.Add(btnCancelarEdicion);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(dgvMovimientos);
            Controls.Add(panelLateral);
            Name = "frmGastosFijos";
            Text = "GastosFijoscs";
            panelLateral.ResumeLayout(false);
            panelLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelLateral;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreGasto;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMovimientos;
        private Guna.UI2.WinForms.Guna2ComboBox cboMedioPago;
        private Guna.UI2.WinForms.Guna2TextBox txtMonto;
        private Label lblNombreDelGasto;
        private Guna.UI2.WinForms.Guna2TextBox txtNotas;
        private Label lblMonto;
        private Label lblVencimiento;
        private Label lblMedioPago;
        private Label lblNotas;
        private Label lblCategoria;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVencimiento;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombreGasto;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colVencimiento;
        private DataGridViewTextBoxColumn colMedioPago;
        private DataGridViewTextBoxColumn colNotas;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnCancelarEdicion;
    }
}