using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EstablecimientoConIVA : Establecimiento
    {
        public override void RealizarCalculos()
        {
            //double ganancia;
            Ganancia = IngresosAnuales - GastosAnuales;
            double UVT = 30000;
            //double valorUVT;
            ValorUVT = Ganancia / UVT;
            //double tarifa;
            if (ValorUVT < 0)
            {
                Tarifa = 0;
                Impuesto = Ganancia * Tarifa;
            }
            else if (ValorUVT > 0 && ValorUVT < 100)
            {
                Tarifa = 0.05;
                Impuesto = Ganancia * Tarifa;
            }
            else if (ValorUVT >= 100 && ValorUVT < 200)
            {
                Tarifa = 0.1;
                Impuesto = Ganancia * Tarifa;
            }
            else if (ValorUVT >= 500)
            {
                Tarifa = 0.15;
                Impuesto = Ganancia * Tarifa;
            }
        }
    }
}
