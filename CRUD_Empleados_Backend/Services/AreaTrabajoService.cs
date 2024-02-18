using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Dapper;
using System.Data;

namespace CRUD_Empleados_Backend.Services
{
    public class AreaTrabajoService : IAreaTrabajo
    {
        private readonly IDapperContext _dapperContext;

        public AreaTrabajoService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<AreaTrabajo>> ObtenerLista()
        {
            IEnumerable<AreaTrabajo> lista = new List<AreaTrabajo>();

            using (var db = _dapperContext.CrearConexion())
            {
                lista = await db.QueryAsync<AreaTrabajo>(
                    sql: "SP_AREA_TRABAJO",
                    param: new { @pOpcion = 0 },
                    commandType: CommandType.StoredProcedure);
            }

            return lista;
        }
    }
}
