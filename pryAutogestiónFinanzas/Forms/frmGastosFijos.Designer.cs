namespace pryAutogestiónFinanzas
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
            lblTitulo = new Label();
            panelLateral = new Panel();
            btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            lblNotas = new Label();
            lblMedioPago = new Label();
            lblNombreDelGasto = new Label();
            lblVencimiento = new Label();
            txtNotas = new Guna.UI2.WinForms.Guna2TextBox();
            lblFrecuencia = new Label();
            cmbMedioPago = new Guna.UI2.WinForms.Guna2ComboBox();
            lblMonto = new Label();
            nupVencimiento = new NumericUpDown();
            lblCategoria = new Label();
            cmbFrecuencia = new Guna.UI2.WinForms.Guna2ComboBox();
            txtMonto = new Guna.UI2.WinForms.Guna2TextBox();
            cmbCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            txtNombreGasto = new Guna.UI2.WinForms.Guna2TextBox();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            panelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nupVencimiento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
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
            panelLateral.Controls.Add(btnAgregar);
            panelLateral.Controls.Add(lblNotas);
            panelLateral.Controls.Add(lblMedioPago);
            panelLateral.Controls.Add(lblNombreDelGasto);
            panelLateral.Controls.Add(lblVencimiento);
            panelLateral.Controls.Add(txtNotas);
            panelLateral.Controls.Add(lblFrecuencia);
            panelLateral.Controls.Add(cmbMedioPago);
            panelLateral.Controls.Add(lblMonto);
            panelLateral.Controls.Add(nupVencimiento);
            panelLateral.Controls.Add(lblCategoria);
            panelLateral.Controls.Add(cmbFrecuencia);
            panelLateral.Controls.Add(txtMonto);
            panelLateral.Controls.Add(cmbCategoria);
            panelLateral.Controls.Add(txtNombreGasto);
            panelLateral.Controls.Add(lblTitulo);
            panelLateral.Location = new Point(-3, -5);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(280, 901);
            panelLateral.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Animated = true;
            btnAgregar.BorderRadius = 10;
            btnAgregar.CustomizableEdges = customizableEdges1;
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
            btnAgregar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregar.Size = new Size(252, 51);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblNotas
            // 
            lblNotas.AutoSize = true;
            lblNotas.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNotas.ForeColor = SystemColors.Window;
            lblNotas.Location = new Point(15, 668);
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
            lblMedioPago.Location = new Point(15, 566);
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
            lblVencimiento.Location = new Point(15, 483);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(186, 21);
            lblVencimiento.TabIndex = 6;
            lblVencimiento.Text = "Día de vencimiento";
            // 
            // txtNotas
            // 
            txtNotas.BorderRadius = 10;
            txtNotas.CustomizableEdges = customizableEdges3;
            txtNotas.DefaultText = "";
            txtNotas.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNotas.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNotas.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNotas.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNotas.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNotas.Font = new Font("Segoe UI", 9F);
            txtNotas.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNotas.Location = new Point(15, 703);
            txtNotas.Margin = new Padding(3, 4, 3, 4);
            txtNotas.Name = "txtNotas";
            txtNotas.PlaceholderText = "";
            txtNotas.SelectedText = "";
            txtNotas.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtNotas.Size = new Size(252, 25);
            txtNotas.TabIndex = 3;
            // 
            // lblFrecuencia
            // 
            lblFrecuencia.AutoSize = true;
            lblFrecuencia.Font = new Font("Century Gothic", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFrecuencia.ForeColor = SystemColors.Window;
            lblFrecuencia.Location = new Point(15, 376);
            lblFrecuencia.Name = "lblFrecuencia";
            lblFrecuencia.Size = new Size(110, 21);
            lblFrecuencia.TabIndex = 5;
            lblFrecuencia.Text = "Frecuencia";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.BackColor = Color.Transparent;
            cmbMedioPago.BorderRadius = 10;
            cmbMedioPago.CustomizableEdges = customizableEdges5;
            cmbMedioPago.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbMedioPago.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbMedioPago.Font = new Font("Segoe UI", 10F);
            cmbMedioPago.ForeColor = Color.FromArgb(68, 88, 112);
            cmbMedioPago.ItemHeight = 30;
            cmbMedioPago.Location = new Point(15, 604);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbMedioPago.Size = new Size(252, 36);
            cmbMedioPago.TabIndex = 3;
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
            // nupVencimiento
            // 
            nupVencimiento.Location = new Point(15, 523);
            nupVencimiento.Name = "nupVencimiento";
            nupVencimiento.Size = new Size(252, 27);
            nupVencimiento.TabIndex = 3;
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
            // cmbFrecuencia
            // 
            cmbFrecuencia.BackColor = Color.Transparent;
            cmbFrecuencia.BorderRadius = 10;
            cmbFrecuencia.CustomizableEdges = customizableEdges7;
            cmbFrecuencia.DrawMode = DrawMode.OwnerDrawFixed;
            cmbFrecuencia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFrecuencia.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbFrecuencia.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbFrecuencia.Font = new Font("Segoe UI", 10F);
            cmbFrecuencia.ForeColor = Color.FromArgb(68, 88, 112);
            cmbFrecuencia.ItemHeight = 30;
            cmbFrecuencia.Location = new Point(15, 414);
            cmbFrecuencia.Name = "cmbFrecuencia";
            cmbFrecuencia.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbFrecuencia.Size = new Size(252, 36);
            cmbFrecuencia.TabIndex = 3;
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
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.Transparent;
            cmbCategoria.BorderRadius = 10;
            cmbCategoria.CustomizableEdges = customizableEdges11;
            cmbCategoria.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCategoria.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCategoria.Font = new Font("Segoe UI", 10F);
            cmbCategoria.ForeColor = Color.FromArgb(68, 88, 112);
            cmbCategoria.ItemHeight = 30;
            cmbCategoria.Location = new Point(15, 219);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbCategoria.Size = new Size(252, 36);
            cmbCategoria.TabIndex = 3;
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
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 4;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(423, 146);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 51;
            guna2DataGridView1.Size = new Size(735, 596);
            guna2DataGridView1.TabIndex = 2;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 29;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // frmGastosFijos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 868);
            Controls.Add(guna2DataGridView1);
            Controls.Add(panelLateral);
            Name = "frmGastosFijos";
            Text = "GastosFijoscs";
            panelLateral.ResumeLayout(false);
            panelLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nupVencimiento).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelLateral;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreGasto;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMedioPago;
        private NumericUpDown nupVencimiento;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFrecuencia;
        private Guna.UI2.WinForms.Guna2TextBox txtMonto;
        private Label lblNombreDelGasto;
        private Guna.UI2.WinForms.Guna2TextBox txtNotas;
        private Label lblMonto;
        private Label lblVencimiento;
        private Label lblMedioPago;
        private Label lblNotas;
        private Label lblCategoria;
        protected Label lblFrecuencia;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
    }
}