using CRUD_Empleados_Backend.Models;

namespace CRUD_Empleados_Backend.Interfaces
{
    public interface ITipoDocumento
    {
        public Task<IEnumerable<TipoDocumento>> ObtenerLista();
    }
}
