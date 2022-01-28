using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//importacion de librerias
using BLL;
using DAL;

namespace UnderControl
{
    public partial class BuscarOrden : Form
    {
        private Conexion conexion;
        private CrearOrden crearOrden;

        public BuscarOrden()
        {
            InitializeComponent();
            // se crea una instancia de la conexion
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
            this.btnConfirmar.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mostrarMensajeError(String texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void limpiarPantalla()
        {
            this.txtId.Clear();
            this.dtpFechaRegistro.ResetText();
            this.dtpFechaEntrega.ResetText();
            this.txtObsProducto.Clear();
        }
        private void buscarCrearOrden()
        {
            try
            {
                //se consulta 
                this.crearOrden = this.conexion.consultarCrearOrden(this.txtId.Text.Trim());

                //se pregunta si tiene datos
                if (this.crearOrden != null)
                {
                    //se rellena el objeto
                    this.txtObsProducto.Text = this.crearOrden.obsProducto;
                    this.dtpFechaRegistro.Text = Convert.ToString(this.crearOrden.fechaRegistro);
                    this.dtpFechaEntrega.Text = Convert.ToString(this.crearOrden.fechaEntrega);                    
                }
                else
                {
                    throw new Exception("No existe la orden");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtId.Text.Trim().Equals(""))
                    throw new Exception("Necesita el ID para realizar la búsqueda");

                this.buscarCrearOrden();
                this.btnConfirmar.Enabled = true;

            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarPantalla();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOrdenes.set_clienteDeOrden(this.crearOrden);
                this.Close();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }

        private void txtId_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarPantallaBusquedaIdOrden();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void mostrarPantallaBusquedaIdOrden()
        {
            try
            {
                FrmBusquedaIdOrden frmBusquedaIdOrden = new FrmBusquedaIdOrden();

                frmBusquedaIdOrden.miPadre5(this);

                frmBusquedaIdOrden.ShowDialog();

                frmBusquedaIdOrden.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void set_IdOrden(string valor)
        {
            this.txtId.Text = valor;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }//
}
