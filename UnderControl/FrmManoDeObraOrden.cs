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
    public partial class FrmManoDeObraOrden : Form
    {
        private Conexion conexion;
        private ManoDeObraOrden manoDeObraOrden;
        public FrmManoDeObraOrden()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mostrarMensajeError(String text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mostrarPantallaBusquedaIdOrden()
        {
            try
            {
                FrmBusquedaIdOrden frmBusquedaIdOrden = new FrmBusquedaIdOrden();

                frmBusquedaIdOrden.miPadre2(this);

                frmBusquedaIdOrden.ShowDialog();

                frmBusquedaIdOrden.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void mostrarPantallaBusquedaEmpleado()
        {
            try
            {
                FrmBusquedaEmpleado frmBusquedaEmpleado = new FrmBusquedaEmpleado();

                frmBusquedaEmpleado.miPadre(this);

                frmBusquedaEmpleado.ShowDialog();

                frmBusquedaEmpleado.Dispose();
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
        public void set_Empleado(string valor)        {
            this.txtEmpleado.Text = valor;
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
        private void txtEmpleado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarPantallaBusquedaEmpleado();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private ManoDeObraOrden crearObjeto()
        {
            try
            {
                this.manoDeObraOrden = new ManoDeObraOrden();

                this.manoDeObraOrden.idOrden = Convert.ToInt32(this.txtIdOrden.Text.Trim());
                this.manoDeObraOrden.idManoObra = Convert.ToInt32(this.txtEmpleado.Text.Trim());
                this.manoDeObraOrden.horas = Convert.ToInt32(this.ndHoras.Text.Trim());


                return manoDeObraOrden;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void limpiarPantalla()
        {
            this.txtIdOrden.Clear();
            this.txtEmpleado.ResetText();
            this.ndHoras.ResetText();
        }
        public void validacionesDatosRequeridos()
        {
            try
            {
                if (this.txtIdOrden.Text.Trim().Equals(""))
                    throw new Exception("No se permite el id de la orden en blanco.");

                if (this.txtEmpleado.Text.Trim().Equals(""))
                    throw new Exception("No se permite el id del empleado en blanco.");

                if (this.ndHoras.Text.Trim().Equals("0"))
                    throw new Exception("No se permite la cantidad de horas en 0.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validacionesDatosRequeridos();
                this.crearObjeto();
                this.conexion.registrarManoObraOrden(this.manoDeObraOrden);
                this.limpiarPantalla();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
    }//Cierre
}
