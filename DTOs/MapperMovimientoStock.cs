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
            if (ms == null) return null;
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
            if (ms == null) return null;
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

        public static DTOResumenAnio ToDTOResumenAnio(ResumenAnio ra)
        {
            if (ra == null) return null;
            return new DTOResumenAnio
            {
                anio = ra.anio,
                tipo = ra.tipo,
                cantMovidas = ra.cantMovidas
            };
        }

        public static ResumenAnio ToResumenAnio(DTOResumenAnio ra)
        {
            if (ra == null) return null;
            return new ResumenAnio
            {
                anio = ra.anio,
                tipo = ra.tipo,
                cantMovidas = ra.cantMovidas
            };
        }
        public static List<DTOResumenAnio> ToListadoResumenDTO(List<ResumenAnio> resumen)
        {
            return resumen.Select(mv => ToDTOResumenAnio(mv)).ToList();
        }

        public static List<DTOMovimientoStock> ToListadoSimpleDTO(List<MovimientoStock> movimientos)
        {
            return movimientos.Select(mv => ToDTOMovimientoStock(mv)).ToList();
        }
    }
}
