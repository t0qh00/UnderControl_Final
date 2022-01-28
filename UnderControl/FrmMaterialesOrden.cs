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
    public partial class FrmMaterialesOrden : Form
    {
        private Conexion conexion;
        private string nombre;
        private List<MaterialesOrden> materiales;
        public FrmMaterialesOrden()
        {
            InitializeComponent();
            // se crea una instancia de la conexion
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
            this.btnAgregarMaterial.Enabled = false;
            this.materiales = new List<MaterialesOrden>();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mostrarMensajeError(String text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mostrarPantallaBusquedaMateriales()
        {
            try
            {
                FrmBusquedaMateriales frmBusquedaMateriales = new FrmBusquedaMateriales();

                frmBusquedaMateriales.miPadre(this);

                frmBusquedaMateriales.ShowDialog();

                frmBusquedaMateriales.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void txtIdMaterial_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarPantallaBusquedaMateriales();
                if (!this.txtIdMaterial.Text.Trim().Equals(""))
                    this.btnAgregarMaterial.Enabled = true;
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        public void set_Id(string valor)
        {
            this.txtIdMaterial.Text = valor;
        }
        public void set_Nombre(string valor)
        {
            this.nombre = valor;
        }
        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.numCantidad.Text.Trim().Equals("0"))
                    throw new Exception("No se permite la cantidad en 0.");

                this.agregarMaterial();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void agregarMaterial()
        {
            try
            {
                MaterialesOrden material = new MaterialesOrden();
                //agregar fila en blanco
                this.dtgDetalle.Rows.Add();
                                
                this.dtgDetalle.Rows[this.dtgDetalle.Rows.Count - 1].Cells["id"].Value = this.txtIdMaterial.Text;
                this.dtgDetalle.Rows[this.dtgDetalle.Rows.Count - 1].Cells["nombreM"].Value = this.nombre;
                this.dtgDetalle.Rows[this.dtgDetalle.Rows.Count - 1].Cells["CantidadM"].Value = this.numCantidad.Value.ToString();

                material.idMaterial = Convert.ToInt32(this.txtIdMaterial.Text);
                material.idOrden = Convert.ToInt32(this.txtIdOrden.Text);
                material.cantidad = Convert.ToInt32(this.numCantidad.Value.ToString());
                this.materiales.Add(material);

                this.txtIdMaterial.Clear();
                this.nombre = "";

                this.btnAgregarMaterial.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void mostrarPantallaBusquedaIdOrden()
        {
            try
            {
                FrmBusquedaIdOrden frmBusquedaIdOrden = new FrmBusquedaIdOrden();

                frmBusquedaIdOrden.miPadre(this);

                frmBusquedaIdOrden.ShowDialog();

                frmBusquedaIdOrden.Dispose();
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
        public void set_IdOrden(string valor)
        {
            this.txtIdOrden.Text = valor;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validacionesDatosRequeridos();
                foreach (var mate in materiales)
                {
                    this.conexion.registrarMaterialesOrden(mate);
                }
                this.limpiarPantalla();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void limpiarPantalla()
        {
            this.txtIdMaterial.Text = "";
            this.txtIdOrden.Text = "";
            this.numCantidad.Value = 0;
            this.dtgDetalle.Rows.Clear();
        }
        public void validacionesDatosRequeridos()
        {
            try
            {
                if (this.txtIdOrden.Text.Trim().Equals(""))
                    throw new Exception("No se permite el id orden en blanco.");

                if (this.materiales.Count == 0)
                    throw new Exception("No se permite la lista de materiales en blanco.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtgDetalle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow item in this.dtgDetalle.SelectedRows)
            {
                dtgDetalle.Rows.RemoveAt(item.Index);
            }
        }

        }//Cierre
}
