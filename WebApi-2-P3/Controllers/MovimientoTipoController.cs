using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.ExcepcionesDominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_2_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoTipoController : ControllerBase
    {

        public ICUAlta<DTOMovimientoTipo> CUAltaMovimientoTipo { get; set; }
        public ICUBaja CUBajaMovimientoTipo { get; set; }
        public ICUBuscarPorId<DTOMovimientoTipo> CUBuscarMovimientoTipo { get; set; }
        public ICUListado<DTOMovimientoTipo> CUListadoMovimientoTipo { get; set; }
        public ICUModificar<DTOMovimientoTipo> CUModificarMovimientoTipo { get; set; }
        
     
         public MovimientoTipoController(ICUAlta<DTOMovimientoTipo> cUAltaMovimientoTipo, ICUBaja cUBajaMovimientoTipo,
             ICUBuscarPorId<DTOMovimientoTipo> cUBuscarMovimientoTipo, ICUListado<DTOMovimientoTipo> cUListadoMovimientoTipo,
             ICUModificar<DTOMovimientoTipo> cUModificarMovimientoTipo)
            {
                CUAltaMovimientoTipo = cUAltaMovimientoTipo;
                CUBajaMovimientoTipo = cUBajaMovimientoTipo;
                CUBuscarMovimientoTipo = cUBuscarMovimientoTipo;
                CUListadoMovimientoTipo = cUListadoMovimientoTipo;
                CUModificarMovimientoTipo = cUModificarMovimientoTipo;
            }


        // GET: api/<MovimientoTipoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movimientoTipo = CUListadoMovimientoTipo.ObtenerListado();
                return Ok(movimientoTipo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<MovimientoTipoController>/5
        [HttpGet("{id}", Name = "BuscarPorId")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El ID debe ser un entero Positivo");

            DTOMovimientoTipo tipo = null;

            try
            {
                tipo = CUBuscarMovimientoTipo.Buscar(id);

                if (tipo == null) return NotFound("El tipo con id " + id + " no existe");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(tipo);

        }

        // POST api/<MovimientoTipoController>
        [HttpPost]
        public IActionResult Post([FromBody] DTOMovimientoTipo? movTipo)
        {
            if (movTipo == null) return BadRequest("Los datos proporcionados estan vacios");
            if (movTipo.nombre.IsNullOrEmpty()) return BadRequest("El campo Nombre no puede ser vacio.");
            if (movTipo.id != 0) return BadRequest("No se debería proporcionar id de tema. El id de tema es generado automáticamente");
            try
            {
                CUAltaMovimientoTipo.Alta(movTipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<MovimientoTipoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DTOMovimientoTipo? movTipo)
        {
            if (movTipo == null) return BadRequest("Los datos proporcionados estan vacios.");
            if (movTipo.nombre.IsNullOrEmpty()) return BadRequest("El campo Nombre no puede ser vacio.");
            if (movTipo.id <= 0) return BadRequest("El ID debe ser un entero Positivo.");
            if (id != movTipo.id) return BadRequest("Los id proporcionados no coinciden.");

            try
            {
                CUModificarMovimientoTipo.Modificar(movTipo);
                return Ok(movTipo);
            }
            catch (DatosInvalidosException ex)
            {
                return  BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<MovimientoTipoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El ID debe ser un entero Positivo");

            try
            {
                CUBajaMovimientoTipo.Baja(id);
                return NoContent();
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
