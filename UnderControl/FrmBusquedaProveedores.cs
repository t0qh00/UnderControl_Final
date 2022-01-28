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
    public partial class FrmBusquedaProveedores : Form
    {
        private Conexion conexion;
        private FrmMateriales frmMateriales;
        public FrmBusquedaProveedores()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
        }

        public void miPadre(FrmMateriales frm)
        {
            this.frmMateriales = frm;
        }
        private void mostrarMensajeError(string texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }                
        private void buscarProveedor(string nombre)
        {
            try
            {
                this.dtgDatos.DataSource = this.conexion.buscarProveedores(nombre).Tables[0];

                this.dtgDatos.AutoResizeColumns();

                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }       
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txbDescripcion_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.buscarProveedor(this.txbDescripcion.Text.Trim());
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void dtgDatos_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                this.frmMateriales.set_IdProveedor(this.dtgDatos.SelectedRows[0].Cells["idProveedor"].Value.ToString());
                this.frmMateriales.set_Nombre(this.dtgDatos.SelectedRows[0].Cells["nombre"].Value.ToString());
                this.Close();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
    }//Cierre
}
