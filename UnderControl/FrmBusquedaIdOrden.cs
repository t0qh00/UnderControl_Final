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

namespace UnderControl
{
    public partial class FrmBusquedaIdOrden : Form
    {
        private Conexion conexion;
        private FrmMaterialesOrden frmMaterialesOrden;
        private FrmCostosIndirectos frmCostosIndirectos;
        private FrmManoDeObraOrden frmManoDeObraOrden;
        private HojaDeCostos hojaDeCostos;
        private FrmEditarOrden frmEditarOrden;
        private BuscarOrden buscarOrden;
        public FrmBusquedaIdOrden()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.obtenerStringConexion());
        }
        public void miPadre(FrmMaterialesOrden frm)
        {
            this.frmMaterialesOrden = frm;
        }
        public void miPadre1(FrmCostosIndirectos frm)
        {
            this.frmCostosIndirectos = frm;
        }
        public void miPadre2(FrmManoDeObraOrden frm)
        {
            this.frmManoDeObraOrden = frm;
        }
        public void miPadre3(HojaDeCostos frm)
        {
            this.hojaDeCostos = frm;
        }
        public void miPadre4(FrmEditarOrden frm)
        {
            this.frmEditarOrden = frm;
        }
        public void miPadre5(BuscarOrden frm)
        {
            this.buscarOrden = frm;
        }
        private void mostrarMensajeError(string texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txbDescripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.buscarIdOrden(this.txbDescripcion.Text.Trim());
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void buscarIdOrden(string idOrden)
        {
            try
            {
                this.dtgDatos.DataSource = this.conexion.buscarIdOrden(idOrden).Tables[0];

                this.dtgDatos.AutoResizeColumns();

                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void dtgDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {


                if (this.frmCostosIndirectos == null && this.frmMaterialesOrden == null && this.frmManoDeObraOrden == null && this.frmEditarOrden == null && this.buscarOrden == null)
                    this.hojaDeCostos.set_IdOrden(this.dtgDatos.SelectedRows[0].Cells["idOrden"].Value.ToString());

                else if (this.frmCostosIndirectos == null && this.frmMaterialesOrden == null && this.hojaDeCostos == null && this.frmEditarOrden == null && this.buscarOrden == null)
                    this.frmManoDeObraOrden.set_IdOrden(this.dtgDatos.SelectedRows[0].Cells["idOrden"].Value.ToString());

                else if (this.frmMaterialesOrden == null && this.frmManoDeObraOrden == null && this.hojaDeCostos == null && this.frmEditarOrden == null && this.buscarOrden == null)
                    this.frmCostosIndirectos.set_IdOrden(this.dtgDatos.SelectedRows[0].Cells["idOrden"].Value.ToString());

                else if (this.frmCostosIndirectos == null && this.frmMaterialesOrden == null && this.hojaDeCostos == null && this.frmManoDeObraOrden == null && this.buscarOrden == null)
                    this.frmEditarOrden.set_IdOrden(this.dtgDatos.SelectedRows[0].Cells["idOrden"].Value.ToString());

                else if (this.frmMaterialesOrden == null && this.frmManoDeObraOrden == null && this.hojaDeCostos == null && this.frmEditarOrden == null && this.frmCostosIndirectos == null)
                    this.buscarOrden.set_IdOrden(this.dtgDatos.SelectedRows[0].Cells["idOrden"].Value.ToString());

                else
                    this.frmMaterialesOrden.set_IdOrden(this.dtgDatos.SelectedRows[0].Cells["idOrden"].Value.ToString());

                this.Close();
            }
            catch (Exception ex)
            {

                this.mostrarMensajeError(ex.Message);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }//Cierre
}
