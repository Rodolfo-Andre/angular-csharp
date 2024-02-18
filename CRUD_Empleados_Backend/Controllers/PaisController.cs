using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Empleados_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPais _paisService;

        public PaisController(IPais paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetAll()
        {
            var lista = await _paisService.ObtenerLista();
            return Ok(lista);
        }
    }
}
