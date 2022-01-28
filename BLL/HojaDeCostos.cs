using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HojaDeCostos
    {
        double totalC = 0, totalM = 0, totalMa = 0;
        public String TotalCostosIndirectos(int cantidad, double precio)
        {
            totalC = cantidad * precio;
            return totalC.ToString();
        }//fin de total de costos indirectos
        public String TotalManoDeObra(double horas, string jornada)
        {
            if (jornada == "Diurna")
            {
                totalM = horas * 1500;
            }
            else {
                totalM = horas * 1750;
            }
            return totalM.ToString();
        }//fin de total de mano de obra
        public String TotalMaterial(int cantidad, double precio)
        {
            totalMa = cantidad * precio;
            return totalMa.ToString();
        }
        public String TotalGeneral()
        {
            double total = 0;
            total = totalC + totalM + totalMa;
            return total.ToString();
        }
    }
}
