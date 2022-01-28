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
    public partial class FrmBusquedaClientes : Form
    {
        private Conexion conexion; 
        private FrmCrearOrden frmCrearOrden;

        public FrmBusquedaClientes()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
        }
        public void miPadre(FrmCrearOrden frm)
        {
            this.frmCrearOrden = frm;
        }
        private void mostrarMensajeError(string texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txbDescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.buscarCliente(this.txbDescripcion.Text.Trim());
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void buscarCliente(string pCedula)
        {
            try
            {
                this.dtgDatos.DataSource = this.conexion.buscarCliente(pCedula).Tables[0];

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
               
                this.frmCrearOrden.set_Cliente(this.dtgDatos.SelectedRows[0].Cells["cedula"].Value.ToString());
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
