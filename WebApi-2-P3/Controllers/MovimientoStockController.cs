using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

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
        public ICUBuscarByEmail<DTOUsuario> CUBuscarByEmail { get; set; }
        public ICUBuscarPorId<DTOParametro> CUBuscarParametro { get; set; }

        public MovimientoStockController(ICUAlta<DTOMovimientoStock> cUAltaMovimientoStock, 
            ICUBuscarPorId<DTOArticulo> cUBuscarArticulo,
            ICUBuscarPorId<DTOMovimientoTipo> cUBuscarMovimientoTipo,
            ICUBuscarByEmail<DTOUsuario> cUBuscarByEmail,
            ICUBuscarPorId<DTOParametro> cUBuscarParametro)
        {
            CUAltaMovimientoStock = cUAltaMovimientoStock;
            CUBuscarArticulo = cUBuscarArticulo;
            CUBuscarMovimientoTipo = cUBuscarMovimientoTipo;
            CUBuscarByEmail = cUBuscarByEmail;
            CUBuscarParametro = cUBuscarParametro;
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
        public IActionResult Post([FromBody] DTOMovimientoStockVista movStock)
        {
            if (movStock == null) return BadRequest("Los datos proporcionados estan vacios");
            if (movStock.email.IsNullOrEmpty()) return BadRequest("El campo Email no puede ser vacio.");
            if (movStock.idArticulo <= 0) return BadRequest("El ID del Articulo debe ser un entero Positivo");
            if (movStock.idMovimientoTipo <= 0) return BadRequest("El ID del Tipo de Movimiento debe ser un entero Positivo");
            if (movStock.cantidadMovidas <= 0) return BadRequest("La cantidad movida debe ser un entero Positivo");
            if (movStock.id != 0) return BadRequest("No se debería proporcionar id de Movimiento Stock. El id de Movimiento Stock es generado automáticamente");

            try
            {
                DTOArticulo articulo = CUBuscarArticulo.Buscar(movStock.idArticulo);
                DTOMovimientoTipo tipo = CUBuscarMovimientoTipo.Buscar(movStock.idMovimientoTipo);
                DTOUsuario usuario = CUBuscarByEmail.BuscarByEmail(movStock.email);
                DTOParametro parametro = CUBuscarParametro.Buscar(1);

                if (parametro.topeMovimiento<movStock.cantidadMovidas) return NotFound("La cantidad que desea mover supera el tope fijado") ;
                if (articulo == null) return NotFound("El articulo con id " + movStock.idMovimientoTipo + " no existe");
                if (tipo == null) return NotFound("El tipo con id " + movStock.idMovimientoTipo + " no existe");
                if (usuario == null) return NotFound("El usuario con el email " + movStock.email + " no existe");
                if (usuario.rol.nombre!="Encargado") return NotFound("El usuario con debe tener rol de Encargado");

                DTOMovimientoStock nuevo = new DTOMovimientoStock()
                {
                    id=movStock.id,
                    articulo= articulo,
                    tipo= tipo,
                    usuario= usuario,
                    cantidadMovidas = movStock.cantidadMovidas
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
