using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//importacion de libreria
using UnderControl.Properties;

//importacion de la capa logica de negocio
using BLL;

namespace UnderControl
{
    public partial class FrmPrincipal : Form
    {
        public static String cedula;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmManoDeObra frmManoDeObra = new FrmManoDeObra();
            frmManoDeObra.ShowDialog();
            frmManoDeObra.Dispose();
        }

        public static string obtenerStringConexion()
        {
            //se lee del app.Config los datos del string de conexion
            return Settings.Default.UnderControlConnectionString;
        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            FrmMateriales frmMateriales = new FrmMateriales();
            frmMateriales.ShowDialog();
            frmMateriales.Dispose();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
            frmClientes.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmOrdenes frmOrdenes = new FrmOrdenes();
            frmOrdenes.ShowDialog();
            frmOrdenes.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static void set_Cedula(string temp)
        {
            try
            {
                cedula = temp;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public string enviarCedula()
        {
            return cedula;
        }

    }// Cierre
}
