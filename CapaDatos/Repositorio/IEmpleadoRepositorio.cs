using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorio
{
    public interface IEmpleadoRepositorio
    {
        Task<List<Empleado>> ObtenerEmpleado();
    }
}
