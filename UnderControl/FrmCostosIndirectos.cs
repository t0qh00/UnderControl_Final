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
    public partial class FrmCostosIndirectos : Form
    {
        private Conexion conexion;
        private CostosIndirectos costosIndirectos;
        private string idOrden;

        public FrmCostosIndirectos()
        {
            InitializeComponent();
            // se crea una instancia de la conexion
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
            this.botones(false);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private CostosIndirectos crearObjeto()
        {
            try
            {
                this.costosIndirectos = new CostosIndirectos();

                this.costosIndirectos.idOrden = Convert.ToInt32(this.txtIdOrden.Text.Trim());
                this.costosIndirectos.motivo = this.txtMotivo.Text.Trim();
                this.costosIndirectos.cantidad = Convert.ToInt32(this.ndCantidad.Text.Trim());
                this.costosIndirectos.fecha = Convert.ToDateTime(this.dtpFecha.Text.Trim());
                this.costosIndirectos.total = Convert.ToDecimal(this.ndTotal.Text.Trim());

                return costosIndirectos;
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
            this.txtIdOrden.Clear();
            this.txtIdCostoIndirecto.Clear();
            this.txtMotivo.Clear();
            this.ndCantidad.ResetText();
            this.dtpFecha.ResetText();
            this.ndTotal.ResetText();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validacionesDatosRequeridos();
                this.crearObjeto();
                this.conexion.registrarCostosIndirectos(this.costosIndirectos);
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdCostoIndirecto.Text.Trim().Equals(""))
                    throw new Exception("Necesita el ID para realizar la búsqueda");

                this.buscarCostosIndirectos();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void buscarCostosIndirectos()
        {
            try
            {
                this.idOrden = this.txtIdCostoIndirecto.Text.Trim();

                //se consulta 
                this.costosIndirectos = this.conexion.consultarCostosIndirectos(this.idOrden);

                //se pregunta si tiene datos
                if (this.costosIndirectos != null)
                {
                    //se rellena el objeto
                    this.txtIdOrden.Text = Convert.ToString(this.costosIndirectos.idOrden);
                    this.txtIdCostoIndirecto.Text = Convert.ToString(this.costosIndirectos.idGastoIndirecto);
                    this.txtMotivo.Text = this.costosIndirectos.motivo;
                    this.ndCantidad.Text = Convert.ToString(this.costosIndirectos.cantidad);
                    this.dtpFecha.Text = Convert.ToString(this.costosIndirectos.fecha);
                    this.ndTotal.Text = Convert.ToString(this.costosIndirectos.total);
                    this.botones(true);
                    this.btnAgregar.Enabled = false;

                }
                else
                {
                    this.btnAgregar.Enabled = true;
                    this.txtIdOrden.Enabled = true;
                    throw new Exception("No existe el costo indirecto");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.modificarCostosIndirectos();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void modificarCostosIndirectos()
        {
            try
            {
                this.crearObjeto();
                this.idOrden = this.txtIdCostoIndirecto.Text.Trim();
                //se utiliza la conexion para enviar el objeto a modificar
                this.conexion.modificarCostosIndirectos(this.costosIndirectos, this.idOrden);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.eliminarCostosIndirectos();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        public void eliminarCostosIndirectos() 
        {
            try
            {
                this.idOrden = this.txtIdCostoIndirecto.Text.Trim();
                this.conexion.eliminarCostosIndirectos(this.idOrden);
            }
            catch (Exception es)
            {

                throw es;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarPantalla();
            this.botones(false);
        }
        public void validacionesDatosRequeridos()
        {
            try
            {
                if (this.txtIdOrden.Text.Trim().Equals(""))
                    throw new Exception("No se permite el id de la orden en blanco");

                if (this.txtMotivo.Text.Trim().Equals(""))
                    throw new Exception("No se permite el motivo en blanco");

                if (this.ndCantidad.Text.Trim().Equals("0"))
                    throw new Exception("No se permite la cantidad en 0");

                if (this.ndTotal.Text.Trim().Equals("0"))
                    throw new Exception("No se permite el total en 0");

                if (this.dtpFecha.Value.Date < DateTime.Now.Date)
                    throw new Exception("No se permite una fecha pasada.");
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtIdOrden_MouseDoubleClick(object sender, MouseEventArgs e)
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

                frmBusquedaIdOrden.miPadre1(this);

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
            this.txtIdOrden.Text = valor;
        }
        private void txtIdCostoIndirecto_KeyPress(object sender, KeyPressEventArgs e)
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
        public void botones(Boolean boo)
        {
            this.btnActualizar.Enabled = boo;
            this.btnAgregar.Enabled = true;
            this.btnEliminar.Enabled = boo;
            this.btnBuscar.Enabled = !boo;
            this.txtIdCostoIndirecto.Enabled = !boo;
        }
        private void txtIdCostoIndirecto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarPantallaBusquedaCostos();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        public void set_Costos(string valor)
        {
            this.txtIdCostoIndirecto.Text = valor;
        }
        private void mostrarPantallaBusquedaCostos()
        {
            try
            {
                FrmBusquedaCostosIndirectos frmBusquedaCostosIndirectos = new FrmBusquedaCostosIndirectos();

                frmBusquedaCostosIndirectos.miPadre(this);

                frmBusquedaCostosIndirectos.ShowDialog();

                frmBusquedaCostosIndirectos.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }//Cierre
}
