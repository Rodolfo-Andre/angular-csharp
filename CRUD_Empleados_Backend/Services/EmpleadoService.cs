using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Dapper;
using System.Data;

namespace CRUD_Empleados_Backend.Services
{
    public class EmpleadoService : IEmpleado
    {
        private readonly IDapperContext _dapperContext;

        public EmpleadoService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<EmpleadoObtener>> ObtenerLista(int estado)
        {
            IEnumerable<EmpleadoObtener> lista = new List<EmpleadoObtener>();

            using (var db = _dapperContext.CrearConexion())
            {
                lista = await db.QueryAsync<EmpleadoObtener>(
                    sql: "SP_EMPLEADO",
                    param: new { @pOpcion = 0, estado },
                    commandType: CommandType.StoredProcedure);
            }

            return lista;
        }

        public async Task<bool> ExisteEmpleado(int idEmpleado)
        {
            bool resultado = false;

            using (var db = _dapperContext.CrearConexion())
            {
                int cantidad = await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM tb_empleado WHERE id = @idEmpleado", new { idEmpleado });
                resultado = cantidad == 1;
            }

            return resultado;
        }

        public async Task<int> Registrar(EmpleadoRegistrar empleado)
        {
            int idEmpleado = 0;
            var parametros = new DynamicParameters(empleado);
            parametros.Add("@pOpcion", 1);

            using (var db = _dapperContext.CrearConexion())
            {
                idEmpleado = await db.ExecuteScalarAsync<int>(
                    sql: "SP_EMPLEADO",
                    param: parametros,
                    commandType: CommandType.StoredProcedure);
            }

            return idEmpleado;
        }

        public async Task<int> Actualizar(EmpleadoActualizar empleado)
        {
            var parametros = new DynamicParameters(empleado);
            parametros.Add("@pOpcion", 2);

            int filasAfectadas = 0;

            using (var db = _dapperContext.CrearConexion())
            {
                filasAfectadas = await db.ExecuteScalarAsync<int>(
                    sql: "SP_EMPLEADO",
                    param: parametros,
                    commandType: CommandType.StoredProcedure);
            }

            return filasAfectadas;
        }

        public async Task<int> EstablecerEstado(int idEmpleado, int estado)
        {
            int filasAfectadas = 0;

            using (var db = _dapperContext.CrearConexion())
            {
                filasAfectadas = await db.ExecuteScalarAsync<int>(
                    sql: "SP_EMPLEADO",
                    param: new { @pOpcion = 3, idEmpleado, estado },
                    commandType: CommandType.StoredProcedure);
            }

            return filasAfectadas;
        }
    }
}
