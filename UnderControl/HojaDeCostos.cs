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
using BLL;

namespace UnderControl
{
    public partial class HojaDeCostos : Form
    {
        private Conexion conexion;
        private CrearOrden crearOrden;
        private string nombre;
        public HojaDeCostos()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
            this.btnFacturar.Enabled = false;                      
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAtras_Click(object sender, EventArgs e)
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

                frmBusquedaIdOrden.miPadre3(this);

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
        private void buscarCrearOrden()
        {
            try
            {
                if (this.txtIdOrden.Text.Trim().Equals(""))
                    throw new Exception("Necesita el ID para realizar la búsqueda");

                //se consulta 
                this.crearOrden = this.conexion.consultarCrearOrden(this.txtIdOrden.Text.Trim());

                //se pregunta si tiene datos
                if (this.crearOrden != null)
                {
                    //se rellena el objeto
                    this.lblCliente.Text = this.crearOrden.cedula;
                    
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
                this.buscarCrearOrden();
                this.buscarCostos(txtIdOrden.Text.Trim());
                this.buscarManoObra(txtIdOrden.Text.Trim());
                this.buscarMaterial(txtIdOrden.Text.Trim());
                this.btnFacturar.Enabled = true;
                this.dtgDetalleMateriales.ReadOnly = true;
                this.totales();

            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        public void set_Nombre(string valor)
        {
            this.nombre = valor;
        }
        private void buscarMaterial(string id)
        {
            try
            {
                this.dtgDetalleMateriales.DataSource = this.conexion.buscarOrdenDeMateriales(id).Tables[0];

                this.dtgDetalleMateriales.AutoResizeColumns();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void buscarManoObra(string id)
        {
            try
            {
                this.dtgDetalleManoObra.DataSource = this.conexion.buscarManoDeOrden(id).Tables[0];

                this.dtgDetalleManoObra.AutoResizeColumns();

                this.dtgDetalleManoObra.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void buscarCostos(string id)
        {
            try
            {
                this.dtgDetalleCostos.DataSource = this.conexion.buscarCostosDeOrden(id).Tables[0];

                this.dtgDetalleCostos.AutoResizeColumns();

                this.dtgDetalleCostos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void totales()
        {
            HojaDeCostosO hoja = new HojaDeCostosO();
            double tC = 0, tM = 0, tMa = 0;
            List<Materiales> ma = new List<Materiales>();
            ma = this.conexion.consultarTotalDeMateriales(this.txtIdOrden.Text.ToString().Trim());
            foreach (var mate in ma)
            {
                tMa = tMa + hoja.TotalMaterial(mate.cantidad, Convert.ToDouble(mate.precio));
            }
            lblMateriales.Text = tMa.ToString();

            List<ManoDeObra> man = new List<ManoDeObra>();
            man = this.conexion.consultarTotalDeManoDeObra(this.txtIdOrden.Text.ToString().Trim());
            foreach (var mate in man)
            {
                tM = tM + hoja.TotalManoDeObra(mate.id, mate.jornada);
            }
            lblManoObra.Text = tM.ToString();

            List<CostosIndirectos> c = new List<CostosIndirectos>();
            c = this.conexion.consultarTotalDeCostosIndirectos(this.txtIdOrden.Text.ToString().Trim());
            foreach (var mate in c)
            {
                tC = tC + hoja.TotalCostosIndirectos(mate.cantidad, Convert.ToDouble(mate.total));
            }
            lblTotalCostos.Text = tC.ToString();

            lblTotalGeneral.Text = hoja.TotalGeneral(Convert.ToDouble(lblMateriales.Text), Convert.ToDouble(lblTotalCostos.Text), Convert.ToDouble(lblManoObra.Text));
        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La orden fue enviada correctamente", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }//Cierre
}
