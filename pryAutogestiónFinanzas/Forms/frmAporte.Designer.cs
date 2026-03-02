namespace pryAutogestiónFinanzas
{
    partial class frmAporte
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            panelLateral = new Guna.UI2.WinForms.Guna2Panel();
            btnAgregarAporte = new Guna.UI2.WinForms.Guna2Button();
            lblNotas = new Label();
            txtNotas = new Guna.UI2.WinForms.Guna2TextBox();
            lblMonto = new Label();
            txtMonto = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblMeta = new Label();
            cmbMetas = new Guna.UI2.WinForms.Guna2ComboBox();
            panelLateral.SuspendLayout();
            SuspendLayout();
            // 
            // panelLateral
            // 
            panelLateral.Controls.Add(btnAgregarAporte);
            panelLateral.Controls.Add(lblNotas);
            panelLateral.Controls.Add(txtNotas);
            panelLateral.Controls.Add(lblMonto);
            panelLateral.Controls.Add(txtMonto);
            panelLateral.Controls.Add(label2);
            panelLateral.Controls.Add(dtpFecha);
            panelLateral.Controls.Add(lblMeta);
            panelLateral.Controls.Add(cmbMetas);
            panelLateral.CustomizableEdges = customizableEdges11;
            panelLateral.FillColor = Color.FromArgb(0, 0, 64);
            panelLateral.Location = new Point(-2, -1);
            panelLateral.Name = "panelLateral";
            panelLateral.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelLateral.Size = new Size(280, 901);
            panelLateral.TabIndex = 0;
            // 
            // btnAgregarAporte
            // 
            btnAgregarAporte.Animated = true;
            btnAgregarAporte.BackColor = Color.DarkGray;
            btnAgregarAporte.BorderRadius = 10;
            btnAgregarAporte.CustomizableEdges = customizableEdges1;
            btnAgregarAporte.DisabledState.BorderColor = Color.DarkGray;
            btnAgregarAporte.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAgregarAporte.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAgregarAporte.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAgregarAporte.FillColor = Color.DarkGray;
            btnAgregarAporte.Font = new Font("Century Gothic", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAgregarAporte.ForeColor = Color.White;
            btnAgregarAporte.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            btnAgregarAporte.Location = new Point(14, 748);
            btnAgregarAporte.Name = "btnAgregarAporte";
            btnAgregarAporte.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregarAporte.Size = new Size(238, 42);
            btnAgregarAporte.TabIndex = 1;
            btnAgregarAporte.Text = "Agregar aporte";
            btnAgregarAporte.Click += btnAgregarAporte_Click;
            // 
            // lblNotas
            // 
            lblNotas.AutoSize = true;
            lblNotas.BackColor = Color.FromArgb(0, 0, 64);
            lblNotas.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNotas.ForeColor = SystemColors.Window;
            lblNotas.Location = new Point(14, 595);
            lblNotas.Name = "lblNotas";
            lblNotas.Size = new Size(173, 23);
            lblNotas.TabIndex = 4;
            lblNotas.Text = "Notas (opcional)";
            // 
            // txtNotas
            // 
            txtNotas.CustomizableEdges = customizableEdges3;
            txtNotas.DefaultText = "";
            txtNotas.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNotas.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNotas.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNotas.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNotas.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNotas.Font = new Font("Segoe UI", 9F);
            txtNotas.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNotas.Location = new Point(14, 632);
            txtNotas.Margin = new Padding(3, 4, 3, 4);
            txtNotas.Name = "txtNotas";
            txtNotas.PlaceholderText = "";
            txtNotas.SelectedText = "";
            txtNotas.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtNotas.Size = new Size(238, 36);
            txtNotas.TabIndex = 1;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.BackColor = Color.FromArgb(0, 0, 64);
            lblMonto.Enabled = false;
            lblMonto.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMonto.ForeColor = SystemColors.Window;
            lblMonto.Location = new Point(14, 403);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(74, 23);
            lblMonto.TabIndex = 3;
            lblMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            txtMonto.CustomizableEdges = customizableEdges5;
            txtMonto.DefaultText = "";
            txtMonto.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMonto.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMonto.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMonto.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMonto.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMonto.Font = new Font("Segoe UI", 9F);
            txtMonto.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMonto.Location = new Point(14, 443);
            txtMonto.Margin = new Padding(3, 4, 3, 4);
            txtMonto.Name = "txtMonto";
            txtMonto.PlaceholderText = "";
            txtMonto.SelectedText = "";
            txtMonto.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtMonto.Size = new Size(238, 36);
            txtMonto.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 64);
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(14, 201);
            label2.Name = "label2";
            label2.Size = new Size(72, 23);
            label2.TabIndex = 2;
            label2.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Checked = true;
            dtpFecha.CustomizableEdges = customizableEdges7;
            dtpFecha.FillColor = SystemColors.Window;
            dtpFecha.Font = new Font("Segoe UI", 9F);
            dtpFecha.Format = DateTimePickerFormat.Long;
            dtpFecha.Location = new Point(14, 253);
            dtpFecha.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpFecha.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpFecha.Size = new Size(238, 36);
            dtpFecha.TabIndex = 1;
            dtpFecha.Value = new DateTime(2026, 2, 13, 22, 53, 37, 796);
            // 
            // lblMeta
            // 
            lblMeta.AutoSize = true;
            lblMeta.BackColor = Color.FromArgb(0, 0, 64);
            lblMeta.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMeta.ForeColor = SystemColors.Window;
            lblMeta.Location = new Point(14, 10);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(108, 23);
            lblMeta.TabIndex = 1;
            lblMeta.Text = "Elija meta";
            // 
            // cmbMetas
            // 
            cmbMetas.BackColor = Color.Transparent;
            cmbMetas.CustomizableEdges = customizableEdges9;
            cmbMetas.DrawMode = DrawMode.OwnerDrawFixed;
            cmbMetas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetas.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbMetas.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbMetas.Font = new Font("Segoe UI", 10F);
            cmbMetas.ForeColor = Color.FromArgb(68, 88, 112);
            cmbMetas.ItemHeight = 30;
            cmbMetas.Location = new Point(14, 63);
            cmbMetas.Name = "cmbMetas";
            cmbMetas.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmbMetas.Size = new Size(238, 36);
            cmbMetas.TabIndex = 1;
            // 
            // frmAporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 868);
            Controls.Add(panelLateral);
            Name = "frmAporte";
            Text = "frmAporte";
            panelLateral.ResumeLayout(false);
            panelLateral.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelLateral;
        private Guna.UI2.WinForms.Guna2TextBox txtNotas;
        private Guna.UI2.WinForms.Guna2TextBox txtMonto;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMetas;
        private Label lblNotas;
        private Label lblMonto;
        private Label label2;
        private Label lblMeta;
        private Guna.UI2.WinForms.Guna2Button btnAgregarAporte;
    }
}