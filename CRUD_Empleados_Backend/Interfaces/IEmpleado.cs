using CRUD_Empleados_Backend.Models;

namespace CRUD_Empleados_Backend.Interfaces
{
    public interface IEmpleado
    {
        public Task<IEnumerable<EmpleadoObtener>> ObtenerLista(int estado);
        public Task<bool> ExisteEmpleado(int idEmpleado);
        public Task<int> Registrar(EmpleadoRegistrar empleado);
        public Task<int> Actualizar(EmpleadoActualizar empleado);
        public Task<int> EstablecerEstado(int idEmpleado, int estado);

    }
}
