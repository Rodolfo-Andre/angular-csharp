using CRUD_Empleados_Backend.Models;

namespace CRUD_Empleados_Backend.Interfaces
{
    public interface IAreaTrabajo
    {
        public Task<IEnumerable<AreaTrabajo>> ObtenerLista();
    }
}
