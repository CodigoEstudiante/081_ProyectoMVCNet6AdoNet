using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.Configuracion;
using CapaDatos.Entidades;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos.Repositorio
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly ConfiguracionConexion _conexion;

        public EmpleadoRepositorio(IOptions<ConfiguracionConexion> conexion)
        {
            _conexion = conexion.Value;
        }


        public async Task<List<Empleado>> ObtenerEmpleado()
        {
            List<Empleado> lista = new List<Empleado>();

            using (var conexion = new SqlConnection(_conexion.CadenaSQL)) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = await cmd.ExecuteReaderAsync()) {

                    while (await dr.ReadAsync()) {

                        lista.Add(new Empleado()
                        {
                            IdEmpleado =  Convert.ToInt32(dr["IdEmpleado"]),
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString()

                        });


                    }
                }


            }

            return lista;
        }
    }
}
