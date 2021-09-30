using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EstablecimientoRepository
    {
        string ruta = @"Establecimientos.txt";

        public void Guardar(Establecimiento establecimiento)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{establecimiento.Identificacion};{establecimiento.Nombre};{establecimiento.IngresosAnuales};{establecimiento.GastosAnuales};{establecimiento.TiempoFuncionamiento};{establecimiento.ResponsabilidadIVA};{establecimiento.Ganancia};{establecimiento.ValorUVT};{establecimiento.Tarifa};{establecimiento.Impuesto};");
            escritor.Close();
            file.Close();
        }

        public Establecimiento Buscar(string identificacion)
        {
            List<Establecimiento> ListaEstablecimientos = Consultar();
            foreach (var item in ListaEstablecimientos)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public List<Establecimiento> Consultar()
        {
            List<Establecimiento> ListaEstablecimientos = new List<Establecimiento>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            var linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                string[] dato = linea.Split(';');
                Establecimiento establecimiento;
                if (dato[5] == ("s") || dato[5] == ("si"))
                {
                    establecimiento = new EstablecimientoConIVA();
                }
                else
                {
                    if (dato[5] == ("n") || dato[5] == ("no"))
                    {
                        establecimiento = new EstablecimientoSinIVA();
                    }
                    else
                    {
                        establecimiento = new EstablecimientoConRST();
                    }
                }
                establecimiento.Identificacion = dato[0];
                establecimiento.Nombre = dato[1];
                establecimiento.IngresosAnuales = double.Parse(dato[2]);
                establecimiento.GastosAnuales = double.Parse(dato[3]);
                establecimiento.TiempoFuncionamiento = int.Parse(dato[4]);
                establecimiento.ResponsabilidadIVA = dato[5];
                establecimiento.Ganancia = double.Parse(dato[6]);
                establecimiento.ValorUVT = double.Parse(dato[7]);
                establecimiento.Tarifa = double.Parse(dato[8]);
                establecimiento.Impuesto = double.Parse(dato[9]);
                ListaEstablecimientos.Add(establecimiento);
            }
            lector.Close();
            file.Close();
            return ListaEstablecimientos;
        }

        public void Eliminar(string identificacion)
        {
            List<Establecimiento> ListaEstablecimientos = new List<Establecimiento>();
            ListaEstablecimientos = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in ListaEstablecimientos)
            {
                if (!item.Identificacion.Equals(identificacion))
                {
                    Guardar(item);
                }
            }
        }
    }
}
