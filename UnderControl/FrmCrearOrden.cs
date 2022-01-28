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
    public partial class FrmCrearOrden : Form
    {
        private Conexion conexion;
        private CrearOrden crearOrden;
        
        
        public FrmCrearOrden()
        {
            InitializeComponent();
            // se crea una instancia de la conexion
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
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
                this.crearOrden.fechaRegistro = Convert.ToDateTime(this.dtpFechaRegistro.Text.Trim());
                this.crearOrden.fechaEntrega = Convert.ToDateTime(this.dtpFechaEntrega.Text.Trim());
                this.crearOrden.obsProducto = this.txtObsProducto.Text.Trim();


                return crearOrden;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void mostrarMensajeError(String texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void limpiarPantalla()
        {
            this.txtCedula.Clear();
            this.dtpFechaRegistro.ResetText();
            this.dtpFechaEntrega.ResetText();
            this.txtObsProducto.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validacionesDatosRequeridos();
                this.crearObjeto();                
                this.conexion.registrarCrearOrden(this.crearOrden);
                FrmOrdenes.set_clienteDeOrden(this.crearOrden);
                this.limpiarPantalla();
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

        public void validacionesDatosRequeridos()
        {
            try
            {
                if (this.txtCedula.Text.Trim().Equals(""))
                    throw new Exception("No se permite la cédula en blanco.");

                if (this.dtpFechaRegistro.Value.Date < DateTime.Now.Date)
                    throw new Exception("No se permite una fecha pasada.");

                if (this.dtpFechaEntrega.Value.Date <= DateTime.Now.Date)
                    throw new Exception("No se permite que la fecha de entrega sea la fecha actual.");

                if (this.txtObsProducto.Text.Trim().Equals(""))
                    throw new Exception("No se permite la observación del producto en blanco.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Para obligar a que sólo se introduzcan números y teclas de retroceso
                if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    //se desactivan teclas
                    e.Handled = true;
                    throw new Exception("No se permiten letras ni espacios en blanco.");
                }
            }
            catch (Exception ex)
            {
                this.mostrarMensajeError(ex.Message);
            }
        }

        private void txtCedula_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarPantallaBusquedaCliente();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void mostrarPantallaBusquedaCliente()
        {
            try
            {
                FrmBusquedaClientes frmBusquedaClientes = new FrmBusquedaClientes();

                frmBusquedaClientes.miPadre(this);

                frmBusquedaClientes.ShowDialog();

                frmBusquedaClientes.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void set_Cliente(string valor)
        {
            this.txtCedula.Text = valor;
        }
    }//Cierre
}
