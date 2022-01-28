using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CostosIndirectos
    {
        public int idOrden { set; get; }
        public int idGastoIndirecto { set; get; }
        public string motivo { set; get; }
        public int cantidad { set; get; }
        public DateTime fecha { set; get; }
        public decimal total { set; get; }
    }
}
