namespace pryAutogestiónFinanzas
{
    partial class frmLogin
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            btnChino = new Guna.UI2.WinForms.Guna2Button();
            btnCarla = new Guna.UI2.WinForms.Guna2Button();
            lblUsuario = new Label();
            lblAutogestionFinanzas = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(btnChino);
            panel1.Controls.Add(btnCarla);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(lblAutogestionFinanzas);
            panel1.Location = new Point(80, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 597);
            panel1.TabIndex = 0;
            // 
            // btnChino
            // 
            btnChino.Animated = true;
            btnChino.BorderRadius = 10;
            btnChino.CustomizableEdges = customizableEdges5;
            btnChino.DisabledState.BorderColor = Color.DarkGray;
            btnChino.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChino.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChino.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChino.FillColor = Color.FromArgb(52, 72, 97);
            btnChino.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnChino.ForeColor = Color.White;
            btnChino.HoverState.FillColor = Color.FromArgb(71, 98, 130);
            btnChino.Location = new Point(400, 460);
            btnChino.Name = "btnChino";
            btnChino.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnChino.Size = new Size(225, 56);
            btnChino.TabIndex = 5;
            btnChino.Text = "Chino";
            btnChino.Click += btnChino_Click;
            // 
            // btnCarla
            // 
            btnCarla.Animated = true;
            btnCarla.BorderRadius = 10;
            btnCarla.CustomizableEdges = customizableEdges7;
            btnCarla.DisabledState.BorderColor = Color.DarkGray;
            btnCarla.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCarla.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCarla.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCarla.FillColor = Color.FromArgb(52, 72, 97);
            btnCarla.Font = new Font("Century Gothic", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCarla.ForeColor = Color.White;
            btnCarla.HoverState.FillColor = Color.FromArgb(71, 98, 130);
            btnCarla.Location = new Point(76, 460);
            btnCarla.Name = "btnCarla";
            btnCarla.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCarla.Size = new Size(225, 56);
            btnCarla.TabIndex = 4;
            btnCarla.Text = "Carla";
            btnCarla.Click += btnCarla_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Century Gothic", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(255, 248);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(174, 26);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Elija su usuario";
            // 
            // lblAutogestionFinanzas
            // 
            lblAutogestionFinanzas.AutoSize = true;
            lblAutogestionFinanzas.Font = new Font("Century Gothic", 22.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAutogestionFinanzas.Location = new Point(128, 152);
            lblAutogestionFinanzas.Name = "lblAutogestionFinanzas";
            lblAutogestionFinanzas.Size = new Size(453, 44);
            lblAutogestionFinanzas.TabIndex = 0;
            lblAutogestionFinanzas.Text = "Autogestión de finanzas";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(905, 699);
            Controls.Add(panel1);
            Name = "frmLogin";
            Text = "frmLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblUsuario;
        private Label lblAutogestionFinanzas;
        private Guna.UI2.WinForms.Guna2Button btnChino;
        private Guna.UI2.WinForms.Guna2Button btnCarla;
    }
}