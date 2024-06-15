using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_2_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoStockController : ControllerBase
    {

        public ICUAlta<DTOMovimientoStock> CUAltaMovimientoStock { get; set; }
        public ICUBuscarPorId<DTOArticulo> CUBuscarArticulo { get; set; }
        public ICUBuscarPorId<DTOMovimientoTipo> CUBuscarMovimientoTipo { get; set; }
        public ICUBuscarPorId<DTOUsuario> CUBuscarUsuario { get; set; }

        public MovimientoStockController(ICUAlta<DTOMovimientoStock> cUAltaMovimientoStock, 
            ICUBuscarPorId<DTOArticulo> cUBuscarArticulo,
            ICUBuscarPorId<DTOMovimientoTipo> cUBuscarMovimientoTipo,
            ICUBuscarPorId<DTOUsuario> cUBuscarUsuario)
        {
            CUAltaMovimientoStock = cUAltaMovimientoStock;
            CUBuscarArticulo = cUBuscarArticulo;
            CUBuscarMovimientoTipo = cUBuscarMovimientoTipo;
            CUBuscarUsuario = cUBuscarUsuario;
        }

        // GET: api/<MovimientoStockController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovimientoStockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovimientoStockController>
        [HttpPost]
        public IActionResult Post([FromBody] DTOMovimientoStockVista movTipo)
        {
            try
            {
                DTOArticulo articulo = CUBuscarArticulo.Buscar(movTipo.idArticulo);
                DTOMovimientoTipo tipo = CUBuscarMovimientoTipo.Buscar(movTipo.idMovimientoTipo);
                DTOUsuario usuario = CUBuscarUsuario.Buscar(movTipo.idUsuario);

                DTOMovimientoStock nuevo = new DTOMovimientoStock()
                {
                    id=movTipo.id,
                    articulo= articulo,
                    tipo= tipo,
                    usuario= usuario,
                    cantidadMovidas = movTipo.cantidadMovidas
                };

                CUAltaMovimientoStock.Alta(nuevo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<MovimientoStockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovimientoStockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
