using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Migrations;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Authorization;
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
        public ICUListadoAnualesPorTipo<DTOResumenAnio> CUListadoAnualesPorTipo { get; set; }
        public ICUListadoArticuloRangoPorFecha<DTOMovimientoStock> CUListadoArticuloRangoPorFecha { get; set; }
        public ICUListadoArticuloTipoDescendente<DTOMovimientoStock> CUListadoArticuloTipoDescendente { get; set; }

        public MovimientoStockController(ICUAlta<DTOMovimientoStock> cUAltaMovimientoStock,
            ICUBuscarPorId<DTOArticulo> cUBuscarArticulo,
            ICUBuscarPorId<DTOMovimientoTipo> cUBuscarMovimientoTipo,
            ICUBuscarByEmail<DTOUsuario> cUBuscarByEmail,
            ICUBuscarPorId<DTOParametro> cUBuscarParametro,
            ICUListadoAnualesPorTipo<DTOResumenAnio> cUListadoAnualesPorTipo,
            ICUListadoArticuloRangoPorFecha<DTOMovimientoStock> cUListadoArticuloRangoPorFecha,
            ICUListadoArticuloTipoDescendente<DTOMovimientoStock> cUListadoArticuloTipoDescendente)
        {
            CUAltaMovimientoStock = cUAltaMovimientoStock;
            CUBuscarArticulo = cUBuscarArticulo;
            CUBuscarMovimientoTipo = cUBuscarMovimientoTipo;
            CUBuscarByEmail = cUBuscarByEmail;
            CUBuscarParametro = cUBuscarParametro;
            CUListadoAnualesPorTipo = cUListadoAnualesPorTipo;
            CUListadoArticuloRangoPorFecha = cUListadoArticuloRangoPorFecha;
            CUListadoArticuloTipoDescendente = cUListadoArticuloTipoDescendente;
        }

        // POST api/<MovimientoStockController>
        [HttpPost]
        [Authorize]
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

                if (parametro == null) return NotFound("Ocurrio un error con los parametros del sistema.");
                if (parametro.topeMovimiento < movStock.cantidadMovidas) return NotFound("La cantidad que desea mover supera el tope fijado");
                if (articulo == null) return NotFound("El articulo con id " + movStock.idMovimientoTipo + " no existe");
                if (tipo == null) return NotFound("El tipo con id " + movStock.idMovimientoTipo + " no existe");
                if (usuario == null) return NotFound("El usuario con el email " + movStock.email + " no existe");
                if (usuario.rol.nombre != "Encargado") return NotFound("El usuario con debe tener rol de Encargado");
                if ((articulo.stock - movStock.cantidadMovidas)<0) return NotFound("La cantidad que desea mover supera el stock disponible");

                DTOMovimientoStock nuevo = new DTOMovimientoStock()
                {
                    id = movStock.id,
                    articulo = articulo,
                    tipo = tipo,
                    usuario = usuario,
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

        // GET api/<MovimientoStockController>
        [HttpGet("ListadoAnualesPorTipo")]
        [Authorize]
        public IActionResult ListadoAnualesPorTipo()
        {
            List<DTOResumenAnio> nuevo = null;

            try
            {
                nuevo = CUListadoAnualesPorTipo.ObtenerListado();
                if (!nuevo.Any())
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(nuevo);
        }

        [HttpGet("ListadoArticuloRangoPorFecha")]
        [Authorize]
        public IActionResult ListadoArticuloRangoPorFecha(DateTime? inicio, DateTime? final, [FromQuery] List<int> idArticulos, int pagina)
        {
            
            if (inicio == null || final == null) return BadRequest("Las fechas no pueden ser vacias");
            if (inicio > final) return BadRequest("La fecha de inicio no puede ser mayor a la del final");
            if (idArticulos == null || idArticulos.Any(id => id <= 0)) return BadRequest("La lista de ID de artículos contiene valores enteros no Positivos");

            List<DTOMovimientoStock> nuevo = null;

            try
            {
                DTOParametro parametro = CUBuscarParametro.Buscar(1);
                if (parametro == null) return NotFound("Ocurrio un error con los parametros del sistema.");
                int cantXPagina = parametro.topePaginado;

                nuevo = CUListadoArticuloRangoPorFecha.ObtenerListado(inicio ?? DateTime.MinValue,final ?? DateTime.MaxValue,idArticulos,pagina, cantXPagina);
                if (!nuevo.Any())
                {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(nuevo);
        }

        [HttpGet("ListadoArticuloTipoDescendente")]
        [Authorize]
        public IActionResult ListadoArticuloTipoDescendente(int idArticulo, int idTipo, int pagina)
        {
            if (idArticulo == null || idArticulo <= 0) return BadRequest("El ID del Articulo debe ser un entero Positivo");
            if (idTipo == null || idTipo <= 0) return BadRequest("El ID del Tipo de Movimiento debe ser un entero Positivo");


            List<DTOMovimientoStock> nuevo = null;

            try
            {
                DTOParametro parametro = CUBuscarParametro.Buscar(1);
                if (parametro == null) return NotFound("Ocurrio un error con los parametros del sistema.");
                int cantXPagina = parametro.topePaginado;

                nuevo = CUListadoArticuloTipoDescendente.ObtenerListado(idArticulo,idTipo, pagina, cantXPagina);
                if (!nuevo.Any())
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(nuevo);
        }
    }
}