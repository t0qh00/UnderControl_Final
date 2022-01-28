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
    public partial class FrmEditarOrden : Form
    {
        private Conexion conexion;
        private CrearOrden crearOrden;

        public FrmEditarOrden()
        {
            InitializeComponent();
            // se crea una instancia de la conexion
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
            this.botones(false);
        }
        private void mostrarMensajeError(String texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private CrearOrden crearObjeto()
        {
            try
            {
                this.crearOrden = new CrearOrden();

                this.crearOrden.cedula = this.txtCedula.Text.Trim();
                this.crearOrden.fechaEntrega = Convert.ToDateTime(this.dtpFechaEntrega.Text.Trim());
                this.crearOrden.obsProducto = this.txtObsProducto.Text.Trim();

                return crearOrden;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarPantalla();
            this.botones(false);
        }
        public void limpiarPantalla()
        {
            this.txtCedula.Clear();
            this.dtpFechaEntrega.ResetText();
            this.txtObsProducto.Clear();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCedula.Text.Trim().Equals(""))
                    throw new Exception("Necesita el ID para realizar la búsqueda");

                this.buscarCrearOrden();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void buscarCrearOrden()
        {
            try
            {
                //  this.idOrden = this.txtidOrden.Text.Trim();

                //se consulta 
                this.crearOrden = this.conexion.consultarCrearOrden(this.txtCedula.Text.Trim());

                //se pregunta si tiene datos
                if (this.crearOrden != null)
                {
                    //se rellena el objeto
                    this.txtObsProducto.Text = this.crearOrden.obsProducto;
                    this.dtpFechaEntrega.Text = Convert.ToString(this.crearOrden.fechaEntrega);
                    this.botones(true);
                }

            }
            catch (Exception ex)
            {
                this.botones(false);
                throw ex;
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.modificarCrearOrden();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void modificarCrearOrden()
        {
            try
            {
                this.crearObjeto();

                //se utiliza la conexion para enviar el objeto a modificar
                this.conexion.modificarCrearOrden(this.crearOrden, this.txtCedula.Text.Trim());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void validacionesDatosRequeridos()
        {
            try
            {
               
                if (this.txtObsProducto.Text.Trim().Equals(""))
                    throw new Exception("No se permite la observación del producto en blanco.");

                if (this.dtpFechaEntrega.Value.Date <= DateTime.Now.Date)
                    throw new Exception("No se permite que la fecha de entrega sea la fecha actual.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtCedula_MouseDoubleClick(object sender, MouseEventArgs e)
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

                frmBusquedaIdOrden.miPadre4(this);

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
            this.txtCedula.Text = valor;
        }
        public void botones(Boolean boo)
        {
            this.btnEditar.Enabled = boo;
            this.btnBuscar.Enabled = !boo;
        }

    }//Cierre
}
