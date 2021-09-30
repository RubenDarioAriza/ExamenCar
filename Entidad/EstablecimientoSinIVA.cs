using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EstablecimientoSinIVA : Establecimiento
    {
        public override void RealizarCalculos()
        {
            //double ganancia;
            Ganancia = IngresosAnuales - GastosAnuales;
            double UVT = 30000;
            //double valorUVT;
            ValorUVT = Ganancia / UVT;
            //double tarifa;
            if (ValorUVT > 100)
            {
                if (TiempoFuncionamiento < 5)
                {
                    Tarifa = 0.01;
                    Impuesto = Ganancia * Tarifa;
                }
                else if (TiempoFuncionamiento >= 5 && TiempoFuncionamiento < 10)
                {
                    Tarifa = 0.02;
                    Impuesto = Ganancia * Tarifa;
                }
                else if (TiempoFuncionamiento >= 10)
                {
                    Tarifa = 0.03;
                    Impuesto = Ganancia * Tarifa;
                }
            }
            else
            {
                Tarifa = 0;
                Impuesto = Ganancia * Tarifa;
            }
        }
    }
}
