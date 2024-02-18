using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Empleados_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumento _tipoDocumentoService;
       
        public TipoDocumentoController(ITipoDocumento tipoDocumentoService)
        {
            _tipoDocumentoService = tipoDocumentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetAll()
        {
            var lista = await _tipoDocumentoService.ObtenerLista();
            return Ok(lista);
        }
    }
}
