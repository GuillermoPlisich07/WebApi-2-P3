using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

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
        
     
         public MovimientoTipoController(ICUAlta<DTOMovimientoTipo> cUAltaMovimientoTipo, ICUBaja cUBajaMovimientoTipo,
             ICUBuscarPorId<DTOMovimientoTipo> cUBuscarMovimientoTipo, ICUListado<DTOMovimientoTipo> cUListadoMovimientoTipo)
            {
                CUAltaMovimientoTipo = cUAltaMovimientoTipo;
                CUBajaMovimientoTipo = cUBajaMovimientoTipo;
                CUBuscarMovimientoTipo = cUBuscarMovimientoTipo;
                CUListadoMovimientoTipo = cUListadoMovimientoTipo;
            }


        // GET: api/<MovimientoTipoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovimientoTipoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovimientoTipoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //try
            //{
            //    List<DTOMovimientoTipo> movTipos = CUAltaMovimientoTipo.Alta(DTOMovimientoTipo movTipos);
            //    return (movTipos);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }

        // PUT api/<MovimientoTipoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovimientoTipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
