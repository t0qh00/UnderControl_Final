using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Materiales
    {
        public int idMaterial { set; get; }
        public string nombre { set; get; }
        public string tipo { set; get; }
        public int cantidad { set; get; }
        public decimal precio { set; get; }
        public string proveedor { set; get; }
    }
}
