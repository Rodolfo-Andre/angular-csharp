using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Dapper;
using System.Data;

namespace CRUD_Empleados_Backend.Services
{
    public class PaisService : IPais
    {
        private readonly IDapperContext _dapperContext;

        public PaisService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Pais>> ObtenerLista()
        {
            IEnumerable<Pais> lista = new List<Pais>();

            using (var db = _dapperContext.CrearConexion())
            {
                lista = await db.QueryAsync<Pais>(
                    sql: "SP_PAIS",
                    param: new { @pOpcion = 0 },
                    commandType: CommandType.StoredProcedure);
            }

            return lista;
        }
    }
}
