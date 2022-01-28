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
    public partial class FrmMateriales : Form
    {
        private Conexion conexion;
        private Materiales materiales;
        private int idMateriales = 0;
        private string id; 

        public FrmMateriales()
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
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validacionesDatosRequeridos();
                this.crearObjetoMateriales();                
                this.conexion.registrarMaterial(this.materiales);
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private Materiales crearObjetoMateriales() 
        {
            try
            {
                this.materiales = new Materiales();

                this.materiales.nombre = this.txtNombre.Text.Trim();
                this.materiales.tipo = this.txtTipo.Text.Trim();
                this.materiales.cantidad = Convert.ToInt32(this.ndCantidad.Text.Trim());
                this.materiales.precio = Convert.ToDecimal(this.ndPrecio.Text.Trim());
                this.materiales.proveedor = this.txtProveedor.Text.Trim();

                return materiales;
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.buscarMaterial();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void buscarMaterial()
        {
            try
            {
                if (this.txtId.Text.Trim().Equals(""))
                    throw new Exception("Necesita el ID para realizar la búsqueda");

                this.idMateriales = Convert.ToInt32(this.txtId.Text.Trim());
                //se consulta el material seleccionado
                this.materiales = this.conexion.consultarMateriales(this.idMateriales);

                //se pregunta si tiene datos
                if (this.materiales != null)
                {
                    //se rellena el front-end con la informacion del objeto
                    this.txtNombre.Text = this.materiales.nombre;
                    this.txtTipo.Text = this.materiales.tipo;
                    this.ndCantidad.Text = Convert.ToString(this.materiales.cantidad);
                    this.ndPrecio.Text = Convert.ToString(this.materiales.precio);
                    this.txtProveedor.Text = this.materiales.proveedor;
                    this.botones(true);
                    this.btnAgregar.Enabled = false;

                }
                else
                {
                    this.btnAgregar.Enabled = true;
                    throw new Exception("No existe el material");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void modificarMaterial()
        {
            try
            {
                this.crearObjetoMateriales();

                //se utiliza la conexion para enviar el objeto a modificar
                this.conexion.modificarMateriales(this.materiales, Convert.ToInt32(this.txtId.Text.Trim()));
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
                this.modificarMaterial();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e) 
        {
            try
            {
                this.eliminar();
                this.limpiarPantalla();
                this.botones(false);
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        public void eliminar()
        {
            try
            {
                this.conexion.eliminarMateriales(Convert.ToInt32(this.txtId.Text.Trim()));
            }
            catch (Exception es)
            {

                throw es;
            }
        }
        public void limpiarPantalla()
        {
            this.txtId.Clear();
            this.txtNombre.Clear();
            this.txtTipo.Clear();
            this.ndCantidad.ResetText();
            this.ndPrecio.ResetText();
            this.txtProveedor.Clear();
        }                         
        public void validacionesDatosRequeridos()
        {
            try
            {
                if (this.txtNombre.Text.Trim().Equals(""))
                    throw new Exception("No se permite el nombre en blanco.");

                if (this.txtTipo.Text.Trim().Equals(""))
                    throw new Exception("No se permite el tipo en blanco.");

                if (this.txtProveedor.Text.Trim().Equals(""))
                    throw new Exception("No se permite el proveedor en blanco");

                if (this.ndPrecio.Text.Trim().Equals("0"))
                    throw new Exception("No se permite el precio en 0.");

                if (this.ndCantidad.Text.Trim().Equals("0"))
                    throw new Exception("No se permite la cantidad en 0.");           
                                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void mostrarPantallaBusquedaProveedores()
        {
            try
            {
                FrmBusquedaProveedores frmBusquedaProveedores = new FrmBusquedaProveedores();

                frmBusquedaProveedores.miPadre(this);

                frmBusquedaProveedores.ShowDialog();

                frmBusquedaProveedores.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void txtProveedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarPantallaBusquedaProveedores();                
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        public void set_IdProveedor(string valor)
        {
            this.id = valor;
        }
        public void set_Nombre(string valor)
        {
            this.txtProveedor.Text = valor;
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

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
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
        public void botones(Boolean boo)
        {
            this.btnActualizar.Enabled = boo;
            this.btnAgregar.Enabled = boo;
            this.btnEliminar.Enabled = boo;
            this.btnBuscar.Enabled = !boo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarPantalla();
            this.botones(false);
        }
    }// Cierre
}// Fin
