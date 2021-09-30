using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Program
    {
        private static Establecimiento establecimiento;
        private static EstablecimientoService establecimientoService = new EstablecimientoService();
        static void Main(string[] args)
        {
            bool seguir = true;
            int opcion;
            do
            {
                Console.WriteLine(" ----- MENU ----- ");
                Console.WriteLine("1. Registrar datos");
                Console.WriteLine("2. Consultar todo");
                Console.WriteLine("3. Eliminar datos");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Digite una opcion");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1: Registrar(); break;
                    case 2: Consultar(); break;
                    case 3: Eliminar(); break;
                    case 4: seguir = false; break;
                }
                Console.ReadKey();
            } while (seguir);
        }

        static void Registrar()
        {
            string identificacion, nombre, reponsabilidadIVA;
            double ingresosAnuales, gastosAnuales;
            int tiempoFuncionamiento;
            Console.WriteLine("Identificacion: ");
            //alcaldia.Identificacion = Console.ReadLine();
            identificacion = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            //alcaldia.Nombre = Console.ReadLine();
            nombre = Console.ReadLine();
            Console.WriteLine("Ingresos Anuales: ");
            //alcaldia.IngresosAnuales = double.Parse(Console.ReadLine());
            ingresosAnuales = double.Parse(Console.ReadLine());
            Console.WriteLine("Gastos Anuales: ");
            //alcaldia.GastosAnuales = double.Parse(Console.ReadLine());
            gastosAnuales = double.Parse(Console.ReadLine());
            Console.WriteLine("Tiempo Funcionamiento (años): ");
            //alcaldia.TiempoFuncionamiento = int.Parse(Console.ReadLine());
            tiempoFuncionamiento = int.Parse(Console.ReadLine());
            Console.WriteLine("Responsabilidad IVA: (s)si, (n)no, (f)otro: ");
            //alcaldia.ResponsabilidadIVA = Console.ReadLine();
            reponsabilidadIVA = Console.ReadLine();
            if (reponsabilidadIVA == ("s") || reponsabilidadIVA == ("si"))
            {
                establecimiento = new EstablecimientoConIVA();
            }
            else
            {
                if (reponsabilidadIVA == ("n") || reponsabilidadIVA == ("no"))
                {
                    establecimiento = new EstablecimientoSinIVA();
                }
                else
                {
                    establecimiento = new EstablecimientoConRST();
                }
            }
            establecimiento.Identificacion = identificacion;
            establecimiento.Nombre = nombre;
            establecimiento.IngresosAnuales = ingresosAnuales;
            establecimiento.GastosAnuales = gastosAnuales;
            establecimiento.TiempoFuncionamiento = tiempoFuncionamiento;
            establecimiento.ResponsabilidadIVA = reponsabilidadIVA;
            establecimiento.RealizarCalculos();
            Console.WriteLine($"El impuesto del establecimiento ´{establecimiento.Nombre}´ es de: {establecimiento.Impuesto}");
            var mensajeGuardar = establecimientoService.Guardar(establecimiento);
            Console.WriteLine(mensajeGuardar);
        }

        static void Consultar()
        {
            List<Establecimiento> ListaEstablecimientos = establecimientoService.Consultar();
            if (ListaEstablecimientos.Count == 0)
            {
                Console.WriteLine("No se han realizado registros");
            }
            else
            {
                foreach (Establecimiento establecimiento in ListaEstablecimientos)
                {
                    Console.WriteLine($"Identificacion: {establecimiento.Identificacion}, " +
                        $"Nombre: {establecimiento.Nombre}, " +
                        $"Ingresos Anuales: {establecimiento.IngresosAnuales}, " +
                        $"Gastos Anuales: {establecimiento.GastosAnuales}, " +
                        $"Tiempo Funcionamiento (años): {establecimiento.TiempoFuncionamiento}, " +
                        $"Responsabilidad IVA: {establecimiento.ResponsabilidadIVA}, " +
                        $"Ganancia: {establecimiento.Ganancia}, " +
                        $"Ganancia en UVT: {establecimiento.ValorUVT}, " +
                        $"Tarifa: {establecimiento.Tarifa}, " +
                        $"Impuesto: {establecimiento.Impuesto}");
                }
            }
        }

        static void Eliminar()
        {
            Consultar();
            Console.WriteLine("Digite la identificacion del establecimiento a eliminar: ");
            string identificacion = Console.ReadLine();
            var mensajeEliminar = establecimientoService.Eliminar(identificacion);
            Console.WriteLine(mensajeEliminar);
            Consultar();
        }
    }
}
