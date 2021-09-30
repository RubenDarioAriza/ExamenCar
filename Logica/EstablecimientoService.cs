using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EstablecimientoService
    {
        EstablecimientoRepository EstablecimientoRespository = new EstablecimientoRepository();

        public string Guardar(Establecimiento establecimiento)
        {
            try
            {
                if (EstablecimientoRespository.Buscar(establecimiento.Identificacion) == null)
                {
                    EstablecimientoRespository.Guardar(establecimiento);
                    return "Datos guardados satisfactoriamente";
                }
                return $"El establecimiento con la identificacion {establecimiento.Identificacion} ya está registrado";
            }
            catch (Exception ex)
            {
                return "Error al guardar: " + ex.Message;
            }
        }

        public List<Establecimiento> Consultar()
        {
            return EstablecimientoRespository.Consultar();
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                if (EstablecimientoRespository.Buscar(identificacion) != null)
                {
                    EstablecimientoRespository.Eliminar(identificacion);
                    return "Datos eliminados satisfactoriamente";
                }
                return $"El establecimiento con la identificacion {identificacion} no está registrado";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }
    }
}