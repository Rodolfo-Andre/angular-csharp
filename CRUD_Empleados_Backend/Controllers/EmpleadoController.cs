using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Empleados_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleado _empleadoService;

        public EmpleadoController(IEmpleado empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("{estado}")]
        public async Task<ActionResult<IEnumerable<EmpleadoObtener>>> GetAll(int estado)
        {
            var lista = await _empleadoService.ObtenerLista(estado);
            return Ok(lista);
        }


        [HttpPost]
        public async Task<ActionResult<Respuesta>> Post([FromBody] EmpleadoRegistrar empleado)
        {
            var respuesta = new Respuesta();

            try
            {
                var id = await _empleadoService.Registrar(empleado);

                respuesta.TipoMensaje = "success";
                respuesta.Mensaje = $"Se ha registrado correctamente el empleado. Su id genereado es el {id}";

                return Ok(respuesta);
            }
            catch (Exception)
            {
                respuesta.TipoMensaje = "error";
                respuesta.Mensaje = "Error al crear un empleado";

                return StatusCode(500, respuesta);
            }
        }


        [HttpPut]
        public async Task<ActionResult<Respuesta>> Put([FromBody] EmpleadoActualizar empleado)
        {
            var respuesta = new Respuesta();

            try
            {
                var existeEmpleado = await _empleadoService.ExisteEmpleado(empleado.IdEmpleado);

                if (!existeEmpleado)
                {
                    respuesta.TipoMensaje = "error";
                    respuesta.Mensaje = $"No existe el empleado nro {empleado.IdEmpleado}";

                    return NotFound(respuesta);
                }

                var filasAfectadas = await _empleadoService.Actualizar(empleado);

                respuesta.TipoMensaje = "success";

                if (filasAfectadas != 0)
                {
                    respuesta.Mensaje = $"Se ha actualizado correctamente el empleado nro {empleado.IdEmpleado}";
                }
                else
                {
                    respuesta.Mensaje = $"No se ha actualizado el empleado {empleado.IdEmpleado}";
                }

                return Ok(respuesta);
            }
            catch (Exception)
            {
                respuesta.TipoMensaje = "error";
                respuesta.Mensaje = "Error al actualizar un empleado";

                return StatusCode(500, respuesta);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Respuesta>> EstablecerEstado([FromBody] EmpleadoEstado empleado)
        {
            var respuesta = new Respuesta();
            var accion = empleado.Estado == 1 ? "activado" : "desactivado";

            try
            {
                var existeEmpleado = await _empleadoService.ExisteEmpleado(empleado.IdEmpleado);

                if (!existeEmpleado)
                {
                    respuesta.TipoMensaje = "error";
                    respuesta.Mensaje = $"No existe el empleado nro {empleado.IdEmpleado}";

                    return NotFound(respuesta);
                }

                var filasAfectadas = await _empleadoService.EstablecerEstado(empleado.IdEmpleado, empleado.Estado);
               
                
                respuesta.TipoMensaje = "success";


                if (filasAfectadas != 0)
                {
                    respuesta.Mensaje = $"Se ha {accion} correctamente el empleado nro {empleado.IdEmpleado}";
                }
                else
                {
                    respuesta.Mensaje = $"No se ha {accion} el empleado {empleado.IdEmpleado}";
                }

                return Ok(respuesta);
            }
            catch (Exception)
            {
                respuesta.TipoMensaje = "error";
                respuesta.Mensaje = $"Error al {accion} un empleado";

                return StatusCode(500, respuesta);
            }
        }
    }
}
