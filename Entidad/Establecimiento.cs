using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public abstract class Establecimiento
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double IngresosAnuales { get; set; }
        public double GastosAnuales { get; set; }
        public int TiempoFuncionamiento { get; set; }
        public string ResponsabilidadIVA { get; set; }
        public double Ganancia { get; set; }
        public double ValorUVT { get; set; }
        public double Tarifa { get; set; }
        public double Impuesto { get; set; }
        public abstract void RealizarCalculos();

        /*public void RealizarCalculos()
        {
            double ganancia;
            ganancia = IngresosAnuales - GastosAnuales;
            double UVT = 30000;
            double valorUVT;
            valorUVT = ganancia / UVT;
            double tarifa;
            if (ResponsabilidadIVA == "s" || ResponsabilidadIVA == "si")
            {
                if (valorUVT < 0)
                {
                    tarifa = 0;
                    Impuesto = ganancia * tarifa;
                }
                else if (valorUVT > 0 && valorUVT < 100)
                {
                    tarifa = 0.05;
                    Impuesto = ganancia * tarifa;
                }
                else if (valorUVT >= 100 && valorUVT < 200 )
                {
                    tarifa = 0.1;
                    Impuesto = ganancia * tarifa;
                }
                else if (valorUVT >= 500)
                {
                    tarifa = 0.15;
                    Impuesto = ganancia * tarifa;
                }
            }
            else if (ResponsabilidadIVA == "n" || ResponsabilidadIVA == "no")
            {
                if (valorUVT > 100)
                {
                    if (TiempoFuncionamiento < 5)
                    {
                        tarifa = 0.01;
                        Impuesto = ganancia * tarifa;
                    }
                    else if (TiempoFuncionamiento >= 5 && TiempoFuncionamiento < 10)
                    {
                        tarifa = 0.02;
                        Impuesto = ganancia * tarifa;
                    }
                    else if (TiempoFuncionamiento >= 10)
                    {
                        tarifa = 0.03;
                        Impuesto = ganancia * tarifa;
                    }
                }
                else
                {
                    tarifa = 0;
                    Impuesto = ganancia * tarifa;
                }
            }
            else
            {
                if (valorUVT > 50)
                {
                    tarifa = 0.05;
                    Impuesto = ganancia * tarifa;
                }
                else
                {
                    tarifa = 0;
                    Impuesto = ganancia * tarifa;
                }
            }
        }*/
    }
}