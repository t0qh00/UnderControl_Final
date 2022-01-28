namespace UnderControl
{
    partial class FrmOrdenes
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.btnRegistroManoDeObra = new System.Windows.Forms.Button();
            this.btnRegistroMateriales = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditarOrden = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnBuscarO = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnVerHoja = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrearOrden = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.btnRegistroManoDeObra);
            this.panelPrincipal.Controls.Add(this.btnRegistroMateriales);
            this.panelPrincipal.Controls.Add(this.btnAgregar);
            this.panelPrincipal.Controls.Add(this.btnEditarOrden);
            this.panelPrincipal.Controls.Add(this.btnCerrar);
            this.panelPrincipal.Controls.Add(this.btnBuscarO);
            this.panelPrincipal.Controls.Add(this.lblCliente);
            this.panelPrincipal.Controls.Add(this.btnVerHoja);
            this.panelPrincipal.Controls.Add(this.label2);
            this.panelPrincipal.Controls.Add(this.btnCrearOrden);
            this.panelPrincipal.Controls.Add(this.pictureBox1);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(800, 450);
            this.panelPrincipal.TabIndex = 1;
            // 
            // btnRegistroManoDeObra
            // 
            this.btnRegistroManoDeObra.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroManoDeObra.Location = new System.Drawing.Point(343, 399);
            this.btnRegistroManoDeObra.Name = "btnRegistroManoDeObra";
            this.btnRegistroManoDeObra.Size = new System.Drawing.Size(231, 39);
            this.btnRegistroManoDeObra.TabIndex = 1;
            this.btnRegistroManoDeObra.Text = "Registro de Mano de Obra";
            this.btnRegistroManoDeObra.UseVisualStyleBackColor = true;
            this.btnRegistroManoDeObra.Click += new System.EventHandler(this.btnRegistroManoDeObra_Click);
            // 
            // btnRegistroMateriales
            // 
            this.btnRegistroMateriales.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroMateriales.Location = new System.Drawing.Point(590, 400);
            this.btnRegistroMateriales.Name = "btnRegistroMateriales";
            this.btnRegistroMateriales.Size = new System.Drawing.Size(204, 38);
            this.btnRegistroMateriales.TabIndex = 2;
            this.btnRegistroMateriales.Text = "Registro de Materiales";
            this.btnRegistroMateriales.UseVisualStyleBackColor = true;
            this.btnRegistroMateriales.Click += new System.EventHandler(this.btnRegistroMateriales_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(66, 399);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(261, 39);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Registro de Costos Indirectos";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditarOrden
            // 
            this.btnEditarOrden.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarOrden.Location = new System.Drawing.Point(529, 277);
            this.btnEditarOrden.Name = "btnEditarOrden";
            this.btnEditarOrden.Size = new System.Drawing.Size(259, 39);
            this.btnEditarOrden.TabIndex = 15;
            this.btnEditarOrden.Text = "Editar Orden";
            this.btnEditarOrden.UseVisualStyleBackColor = true;
            this.btnEditarOrden.Click += new System.EventHandler(this.btnEditarOrden_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(773, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnBuscarO
            // 
            this.btnBuscarO.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarO.Location = new System.Drawing.Point(279, 277);
            this.btnBuscarO.Name = "btnBuscarO";
            this.btnBuscarO.Size = new System.Drawing.Size(244, 39);
            this.btnBuscarO.TabIndex = 14;
            this.btnBuscarO.Text = "Buscar Orden";
            this.btnBuscarO.UseVisualStyleBackColor = true;
            this.btnBuscarO.Click += new System.EventHandler(this.btnBuscarO_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(153, 110);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(16, 25);
            this.lblCliente.TabIndex = 13;
            this.lblCliente.Text = ".";
            // 
            // btnVerHoja
            // 
            this.btnVerHoja.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerHoja.Location = new System.Drawing.Point(279, 322);
            this.btnVerHoja.Name = "btnVerHoja";
            this.btnVerHoja.Size = new System.Drawing.Size(244, 39);
            this.btnVerHoja.TabIndex = 3;
            this.btnVerHoja.Text = "Ver Hoja de Costos";
            this.btnVerHoja.UseVisualStyleBackColor = true;
            this.btnVerHoja.Click += new System.EventHandler(this.btnVerHoja_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cliente:";
            // 
            // btnCrearOrden
            // 
            this.btnCrearOrden.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearOrden.Location = new System.Drawing.Point(12, 277);
            this.btnCrearOrden.Name = "btnCrearOrden";
            this.btnCrearOrden.Size = new System.Drawing.Size(261, 39);
            this.btnCrearOrden.TabIndex = 11;
            this.btnCrearOrden.Text = "Crear Orden";
            this.btnCrearOrden.UseVisualStyleBackColor = true;
            this.btnCrearOrden.Click += new System.EventHandler(this.btnCrearOrden_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UnderControl.Properties.Resources.Modulo_de_ordenes_Prueba_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FrmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrdenes";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button btnVerHoja;
        private System.Windows.Forms.Button btnRegistroMateriales;
        private System.Windows.Forms.Button btnRegistroManoDeObra;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrearOrden;
        private System.Windows.Forms.Button btnEditarOrden;
        private System.Windows.Forms.Button btnBuscarO;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}