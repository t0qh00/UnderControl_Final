using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

//importacion de librerias
using BLL;
using DAL;

//importar librerias para el correo
using System.Net.Mail;
using System.Net;

namespace UnderControl
{
    public partial class FrmClientes : Form
    {
        private Conexion conexion;
        private Clientes clientes;
        private string cedulaC;

        public FrmClientes()
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

        private Clientes crearObjtoCliente()
        {
            try
            {
                this.clientes = new Clientes();

                this.clientes.cedula = this.txtCedula.Text.Trim();
                this.clientes.nombre = this.txtNombre.Text.Trim();
                this.clientes.email = this.txtEmail.Text.Trim();
                this.clientes.telefono = this.txtTelefono.Text.Trim();

                return clientes;
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
            this.txtNombre.Clear();
            this.txtEmail.Clear();
            this.txtTelefono.Clear();
            this.botones(false);

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
                    this.crearObjtoCliente();
                    this.conexion.registrarCliente(this.clientes);
                    this.SendMail();
                    this.limpiarPantalla();
                    this.botones(false);
                }
                
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
                this.buscarCliente();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }

        private void buscarCliente()
        {
            try
            {
                if (this.txtCedula.Text.Trim().Equals(""))
                    throw new Exception("Necesita la cédula para realizar la búsqueda");

                this.cedulaC = this.txtCedula.Text.Trim();

                //se consulta el cliente seleccionado
                this.clientes = this.conexion.consultarCliente(this.cedulaC);

                //se pregunta si tiene datos
                if (this.clientes != null)
                {
                    //se rellena el objeto
                    this.txtCedula.Text = this.clientes.cedula;
                    this.txtNombre.Text = this.clientes.nombre;
                    this.txtEmail.Text = this.clientes.email;
                    this.txtTelefono.Text = this.clientes.telefono;
                    this.botones(true);
                    this.btnAgregar.Enabled = false;

                }
                else
                {
                    this.btnAgregar.Enabled = true;
                    throw new Exception("No existe el cliente");
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
                this.modificarCliente();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }

        private void modificarCliente()
        {
            try
            {
                this.crearObjtoCliente();

                //se utiliza la conexion para enviar el objeto a modificar
                this.conexion.modificarCliente(this.clientes, this.txtCedula.Text.Trim());
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
                this.eliminarCliente();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }

        public void eliminarCliente()
        {
            try
            {
                this.conexion.eliminarCliente(this.txtCedula.Text.Trim());
            }
            catch (Exception es)
            {

                throw es;
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
                if (this.txtNombre.Text.Trim().Equals(""))
                    throw new Exception("No se permite el nombre en blanco.");

                if (this.txtCedula.Text.Trim().Equals(""))
                    throw new Exception("No se permite la cédula en blanco.");                                           

                if (this.txtTelefono.Text.Trim().Equals(""))
                    throw new Exception("No se permite el teléfono en blanco.");

                if (this.txtEmail.Text.Trim().Equals(""))
                    throw new Exception("No se permite el email en blanco.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
              
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        public static bool validarEmail (string email)
        {
            string formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if(Regex.IsMatch(email, formato))
            {
                if(Regex.Replace(email, formato, string.Empty).Length == 0)
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
        public Boolean SendMail()
        {

            try
            {
                // Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("undercontrolp@gmail.com", "UnderControl", Encoding.UTF8);

                //Aquí ponemos el asunto del correo
                mail.Subject = "Registro en Under Control";

                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = "Gracias " + this.txtNombre.Text.Trim() + ", cédula " + this.txtCedula.Text.Trim() + " por ser parte de nuestra empresa!.";
               
                //Especificamos a quien enviaremos el Email
                mail.To.Add(this.txtEmail.Text.Trim());

                //Configuracion el puerto
                SmtpServer.Port = 587; 

                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("undercontrolp@gmail.com", "underControl2020");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
        public void botones( Boolean boo)
        {
            this.btnActualizar.Enabled = boo;
            this.btnAgregar.Enabled = boo;
            this.btnEliminar.Enabled = boo;
            this.btnBuscar.Enabled = !boo;
        }
    }//Cierre
}
