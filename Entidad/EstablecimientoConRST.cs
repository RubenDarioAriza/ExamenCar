using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EstablecimientoConRST : Establecimiento
    {
        public override void RealizarCalculos()
        {
            //double ganancia;
            Ganancia = IngresosAnuales - GastosAnuales;
            double UVT = 30000;
            //double valorUVT;
            ValorUVT = Ganancia / UVT;
            //double tarifa;
            if (ValorUVT > 50)
            {
                Tarifa = 0.05;
                Impuesto = Ganancia * Tarifa;
            }
            else
            {
                Tarifa = 0;
                Impuesto = Ganancia * Tarifa;
            }
        }
    }
}
