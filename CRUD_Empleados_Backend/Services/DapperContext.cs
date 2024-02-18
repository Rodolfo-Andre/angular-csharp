using CRUD_Empleados_Backend.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Empleados_Backend.Services
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IDbConnection CrearConexion()
        {
            return new SqlConnection(_configuration.GetConnectionString("ContextoBD"));
        }
    }
}
