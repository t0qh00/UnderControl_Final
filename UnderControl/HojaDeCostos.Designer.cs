
namespace UnderControl
{
    partial class HojaDeCostos
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dtgDetalleCostos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgDetalleManoObra = new System.Windows.Forms.DataGridView();
            this.dtgDetalleMateriales = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotalCostos = new System.Windows.Forms.Label();
            this.lblMateriales = new System.Windows.Forms.Label();
            this.lblManoObra = new System.Windows.Forms.Label();
            this.txtIdOrden = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleManoObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(540, 399);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(115, 32);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(665, 399);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(115, 32);
            this.btnFacturar.TabIndex = 2;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Location = new System.Drawing.Point(766, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(28, 26);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dtgDetalleCostos
            // 
            this.dtgDetalleCostos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDetalleCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleCostos.Location = new System.Drawing.Point(74, 196);
            this.dtgDetalleCostos.Name = "dtgDetalleCostos";
            this.dtgDetalleCostos.RowHeadersWidth = 51;
            this.dtgDetalleCostos.Size = new System.Drawing.Size(154, 160);
            this.dtgDetalleCostos.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(54, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "IdOrden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(536, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Costos indirectos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(299, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mano de Obra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(536, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Materiales:";
            // 
            // dtgDetalleManoObra
            // 
            this.dtgDetalleManoObra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDetalleManoObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleManoObra.Location = new System.Drawing.Point(303, 196);
            this.dtgDetalleManoObra.Name = "dtgDetalleManoObra";
            this.dtgDetalleManoObra.RowHeadersWidth = 51;
            this.dtgDetalleManoObra.Size = new System.Drawing.Size(154, 160);
            this.dtgDetalleManoObra.TabIndex = 10;
            // 
            // dtgDetalleMateriales
            // 
            this.dtgDetalleMateriales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDetalleMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleMateriales.Location = new System.Drawing.Point(540, 196);
            this.dtgDetalleMateriales.Name = "dtgDetalleMateriales";
            this.dtgDetalleMateriales.RowHeadersWidth = 51;
            this.dtgDetalleMateriales.Size = new System.Drawing.Size(154, 160);
            this.dtgDetalleMateriales.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(54, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(299, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 28);
            this.label7.TabIndex = 13;
            this.label7.Text = "Total:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(536, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 28);
            this.label8.TabIndex = 14;
            this.label8.Text = "Total:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(607, 117);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(16, 28);
            this.lblCliente.TabIndex = 17;
            this.lblCliente.Text = ".";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UnderControl.Properties.Resources.HojaDeCostos;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotalCostos
            // 
            this.lblTotalCostos.AutoSize = true;
            this.lblTotalCostos.BackColor = System.Drawing.Color.White;
            this.lblTotalCostos.Location = new System.Drawing.Point(111, 359);
            this.lblTotalCostos.Name = "lblTotalCostos";
            this.lblTotalCostos.Size = new System.Drawing.Size(16, 28);
            this.lblTotalCostos.TabIndex = 18;
            this.lblTotalCostos.Text = ".";
            // 
            // lblMateriales
            // 
            this.lblMateriales.AutoSize = true;
            this.lblMateriales.BackColor = System.Drawing.Color.White;
            this.lblMateriales.Location = new System.Drawing.Point(593, 359);
            this.lblMateriales.Name = "lblMateriales";
            this.lblMateriales.Size = new System.Drawing.Size(16, 28);
            this.lblMateriales.TabIndex = 19;
            this.lblMateriales.Text = ".";
            // 
            // lblManoObra
            // 
            this.lblManoObra.AutoSize = true;
            this.lblManoObra.BackColor = System.Drawing.Color.White;
            this.lblManoObra.Location = new System.Drawing.Point(356, 359);
            this.lblManoObra.Name = "lblManoObra";
            this.lblManoObra.Size = new System.Drawing.Size(16, 28);
            this.lblManoObra.TabIndex = 13;
            this.lblManoObra.Text = ".";
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Location = new System.Drawing.Point(134, 109);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.ReadOnly = true;
            this.txtIdOrden.Size = new System.Drawing.Size(100, 34);
            this.txtIdOrden.TabIndex = 20;
            this.txtIdOrden.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtIdOrden_MouseDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(303, 109);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 32);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightSlateGray;
            this.label9.Location = new System.Drawing.Point(54, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 28);
            this.label9.TabIndex = 15;
            this.label9.Text = "Total general:";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblTotalGeneral.Location = new System.Drawing.Point(172, 410);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(16, 28);
            this.lblTotalGeneral.TabIndex = 22;
            this.lblTotalGeneral.Text = ".";
            // 
            // HojaDeCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 449);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdOrden);
            this.Controls.Add(this.lblMateriales);
            this.Controls.Add(this.lblTotalCostos);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblManoObra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtgDetalleMateriales);
            this.Controls.Add(this.dtgDetalleManoObra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgDetalleCostos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HojaDeCostos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleManoObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dtgDetalleCostos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgDetalleManoObra;
        private System.Windows.Forms.DataGridView dtgDetalleMateriales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblTotalCostos;
        private System.Windows.Forms.Label lblMateriales;
        private System.Windows.Forms.Label lblManoObra;
        private System.Windows.Forms.TextBox txtIdOrden;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalGeneral;
    }
}