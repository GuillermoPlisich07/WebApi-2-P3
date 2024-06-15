using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperMovimientoStock
    {
        public static DTOMovimientoStock ToDTOMovimientoStock(MovimientoStock ms)
        {
            return new DTOMovimientoStock
            {
                id = ms.id,
                fechaDeMovimiento = ms.fechaDeMovimiento,
                articulo = MapperArticulo.ToDTOArticulo(ms.articulo),
                tipo = MapperMovimientoTipo.ToDTOMovimientoTipo(ms.tipo),
                usuario = MapperUsuario.ToDTOUsuario(ms.usuario),
                cantidadMovidas = ms.cantidadMovidas
            };
        }

        public static MovimientoStock ToMovimientoStock(DTOMovimientoStock ms)
        {
            return new MovimientoStock
            {
                id = ms.id,
                fechaDeMovimiento = ms.fechaDeMovimiento,
                articulo = MapperArticulo.ToArticulo(ms.articulo),
                tipo = MapperMovimientoTipo.ToMovimientoTipo(ms.tipo),
                usuario = MapperUsuario.ToUsuario(ms.usuario),
                cantidadMovidas = ms.cantidadMovidas
            };
        }

        public static List<DTOMovimientoStock> ToListadoSimpleDTO(List<MovimientoStock> movimientos)
        {
            return movimientos.Select(mv => ToDTOMovimientoStock(mv)).ToList();
        }
    }
}
