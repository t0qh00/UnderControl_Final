using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;

namespace UnderControl
{
    public partial class FrmBusquedaCostosIndirectos : Form
    {
        private Conexion conexion; 
        private FrmCostosIndirectos frmCostosIndirectos;

        public FrmBusquedaCostosIndirectos()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
        }
        public void miPadre(FrmCostosIndirectos frm)
        {
            this.frmCostosIndirectos = frm;
        }
        private void mostrarMensajeError(string texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txbDescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.buscarCosto(this.txbDescripcion.Text.Trim());
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void buscarCosto(string pId)
        {
            try
            {
                this.dtgDatos.DataSource = this.conexion.buscarCostosIndirectos(pId).Tables[0];

                this.dtgDatos.AutoResizeColumns();

                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void dtgDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {   
               
                this.frmCostosIndirectos.set_Costos(this.dtgDatos.SelectedRows[0].Cells["idGastoIndirecto"].Value.ToString());
                this.Close();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }//Cierre
}
