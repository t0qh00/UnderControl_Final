using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Exportacaion
using System.Text.RegularExpressions;
using BLL;
using DAL;

namespace UnderControl
{
    public partial class FrmManoDeObra : Form
    {
        private Conexion conexion;
        private ManoDeObra manoDeObra;
        public FrmManoDeObra()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
            this.cboxJornada.SelectedIndex = 0;
            this.botones(false);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mostrarMensajeError(String texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private ManoDeObra crearObjtoManoDeObra()
        {
            try
            {
                this.manoDeObra = new ManoDeObra();

                this.manoDeObra.cedula = this.txtCedula.Text.Trim();
                this.manoDeObra.nombre = this.txtNombre.Text.Trim();
                this.manoDeObra.email = this.txtEmail.Text.Trim();
                this.manoDeObra.jornada = this.cboxJornada.Text.Trim();
                this.manoDeObra.estado = "Contratado";

                return manoDeObra;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void limpiarPantalla()
        {
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtEmail.Clear();
            this.cboxJornada.SelectedIndex = 0;
            this.txtId.Clear();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarPantalla();
            this.botones(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.buscarManoDeObra();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }

        private void buscarManoDeObra()
        {
            try
            {
                if (this.txtId.Text.Trim().Equals(""))
                    throw new Exception("Necesita el ID para realizar la búsqueda");

                //se consulta 
                this.manoDeObra = this.conexion.consultarManoDeObra(this.txtId.Text.ToString().Trim());

                //se pregunta si tiene datos
                if (this.manoDeObra != null)
                {
                    //se rellena el objeto
                    this.txtCedula.Text = this.manoDeObra.cedula;
                    this.txtNombre.Text = this.manoDeObra.nombre;
                    this.txtEmail.Text = this.manoDeObra.email;
                    this.cboxJornada.Text = this.manoDeObra.jornada;
                    this.botones(true);
                    this.btnAgregar.Enabled = false;                    

                }
                else
                {
                    this.btnAgregar.Enabled = true;
                    throw new Exception("No existe el empleado");
                }

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
                //Validar el corre
                if (!validarEmail(txtEmail.Text.Trim()))
                {
                    this.validacionesDatosRequeridos();
                    MessageBox.Show("Dirección de correo incorrecto, debe de tener el formato: nombre@dominio.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    txtEmail.Focus();
                }
                else
                {
                    this.validacionesDatosRequeridos();
                    this.crearObjtoManoDeObra();
                    this.conexion.registrarManoDeObra(this.manoDeObra);
                    this.limpiarPantalla();
                    this.botones(false);
                }
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validacionesDatosRequeridos();
                this.modificarManoDeObra();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void modificarManoDeObra()
        {
            try
            {
                this.crearObjtoManoDeObra();
                //se utiliza la conexion para enviar el objeto a modificar
                this.conexion.modificarManoDeObra(this.manoDeObra, this.txtId.Text.ToString().Trim());
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
                this.eliminarManoDeObra();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarManoDeObra()
        {
            try
            {
                this.conexion.eliminarManoDeObra(this.txtId.Text.ToString().Trim());
            }
            catch (Exception es)
            {

                throw es;
            }
        }
        public void validacionesDatosRequeridos()
        {
            try
            {
                if (this.txtNombre.Text.Trim().Equals(""))
                    throw new Exception("No se permite el nombre en blanco.");

                if (this.txtCedula.Text.Trim().Equals(""))
                    throw new Exception("No se permite la cédula en blanco.");

                if (this.txtEmail.Text.Trim().Equals(""))
                    throw new Exception("No se permite el email en blanco.");

                if (this.cboxJornada.Text.Trim().Equals("Seleccione una categoria"))
                    throw new Exception("Debe elegir una jornada");
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
        public static bool validarEmail(string email)
        {
            string formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, formato))
            {
                if (Regex.Replace(email, formato, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Para obligar a que sólo se introduzcan letras
                if (Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    throw new Exception("No se permiten números ni signos.");
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
            this.btnAgregar.Enabled = boo;
            this.btnEliminar.Enabled = boo;
            this.btnBuscar.Enabled = !boo;
        }
    }//
}//
