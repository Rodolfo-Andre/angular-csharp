using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Empleados_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaTrabajoController : ControllerBase
    {
        private readonly IAreaTrabajo _areaTrabajoService;
       
        public AreaTrabajoController(IAreaTrabajo areaTrabajoService)
        {
            _areaTrabajoService = areaTrabajoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaTrabajo>>> GetAll()
        {
            var lista = await _areaTrabajoService.ObtenerLista();
            return Ok(lista);
        }
    }
}
