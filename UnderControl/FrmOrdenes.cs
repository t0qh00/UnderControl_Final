using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
using DAL;

namespace UnderControl
{
    public partial class FrmOrdenes : Form
    {
        private Conexion conexion;
        private static CrearOrden crearOrden;

        public FrmOrdenes()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            FrmCrearOrden frmCrearOrden = new FrmCrearOrden();
            frmCrearOrden.ShowDialog();
            frmCrearOrden.Dispose();
            this.llenarLbl();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCostosIndirectos frmCostosIndirectos = new FrmCostosIndirectos();
            frmCostosIndirectos.ShowDialog();
            frmCostosIndirectos.Dispose(); 
        }
        private void btnRegistroManoDeObra_Click(object sender, EventArgs e)
        {
            FrmManoDeObraOrden frmManoDeObraOrden = new FrmManoDeObraOrden();
            frmManoDeObraOrden.ShowDialog();
            frmManoDeObraOrden.Dispose();
        }
        private void btnRegistroMateriales_Click(object sender, EventArgs e)
        {
            FrmMaterialesOrden frmMaterialesOrden = new FrmMaterialesOrden();
            frmMaterialesOrden.ShowDialog();
            frmMaterialesOrden.Dispose();
        }
        private void btnBuscarO_Click(object sender, EventArgs e)
        {
            BuscarOrden buscarOrden = new BuscarOrden();
            buscarOrden.ShowDialog();
            buscarOrden.Dispose();
            this.llenarLbl();
        }
        private void btnEditarOrden_Click(object sender, EventArgs e)
        {
            FrmEditarOrden frmEditarOrden = new FrmEditarOrden();
            frmEditarOrden.ShowDialog();
            frmEditarOrden.Dispose();
        }
        public static void set_clienteDeOrden(CrearOrden temp)
        {             
            try
            {
                crearOrden = temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void llenarLbl()
        {
            try
            {
                if (crearOrden != null)
                {
                    this.lblCliente.Text = crearOrden.cedula;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnVerHoja_Click(object sender, EventArgs e)
        {
            HojaDeCostos hojaDeCostos = new HojaDeCostos();
            hojaDeCostos.ShowDialog();
            hojaDeCostos.Dispose();
        }
    }//Cierre
}
