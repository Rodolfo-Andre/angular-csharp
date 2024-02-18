using System.Data;

namespace CRUD_Empleados_Backend.Interfaces
{
    public interface IDapperContext
    {
        public IDbConnection CrearConexion();
    }
}
