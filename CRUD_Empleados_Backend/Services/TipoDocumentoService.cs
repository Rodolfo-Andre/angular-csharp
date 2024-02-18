using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Dapper;
using System.Data;

namespace CRUD_Empleados_Backend.Services
{
    public class TipoDocumentoService : ITipoDocumento
    {
        private readonly IDapperContext _dapperContext;

        public TipoDocumentoService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerLista()
        {
            IEnumerable<TipoDocumento> lista = new List<TipoDocumento>();

            using (var db = _dapperContext.CrearConexion())
            {
                lista = await db.QueryAsync<TipoDocumento>(
                    sql: "SP_TIPO_DOCUMENTO",
                    param: new { @pOpcion = 0 },
                    commandType: CommandType.StoredProcedure);
            }

            return lista;
        }
    }
}
