using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HojaDeCostosO
    {
        double totalC = 0, totalM = 0, totalMa = 0;
        public double TotalCostosIndirectos(int cantidad, double precio)
        {
            totalC = cantidad * precio;
            return totalC;
        }//fin de total de costos indirectos
        public double TotalManoDeObra(double horas, string jornada)
        {
            if (jornada == "Diurna")
            {
                totalM = horas * 1500;
            }
            else {
                totalM = horas * 1750;
            }
            return totalM;
        }//fin de total de mano de obra
        public double TotalMaterial(int cantidad, double precio)
        {
            totalMa = cantidad * precio;
            return totalMa;
        }
        public String TotalGeneral(double tC, double tM, double tMa)
        {
            double total = 0;
            total = tC + tM + tMa;
            return total.ToString();
        }
    }
}
