using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_2_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public ICUListado<DTOArticulo> CUListadoArticulo { get; set; }

        public ArticuloController(ICUListado<DTOArticulo> cUListadoArticulo)
        {
            CUListadoArticulo = cUListadoArticulo;
        }

        // GET: api/<ArticuloController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movimientoTipo = CUListadoArticulo.ObtenerListado();
                return Ok(movimientoTipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
