using CRUD_Empleados_Backend.Models;

namespace CRUD_Empleados_Backend.Interfaces
{
    public interface IPais
    {
        public Task<IEnumerable<Pais>> ObtenerLista();
    }
}
