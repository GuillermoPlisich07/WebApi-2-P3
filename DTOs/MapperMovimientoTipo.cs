using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperMovimientoTipo
    {
        public static MovimientoTipo ToMovimientoTipo(DTOMovimientoTipo movimientoTipo)
        {
            return new MovimientoTipo()
            {
                id = movimientoTipo.id,
                nombre = movimientoTipo.nombre,
                incrDecre = movimientoTipo.incrDecre
            };
        }

        public static DTOMovimientoTipo ToDTOMovimientoTipo(MovimientoTipo tipo) 
        {
            return new DTOMovimientoTipo()
            {
                id = tipo.id,
                nombre = tipo.nombre,
                incrDecre = tipo.incrDecre
            };
        }

        public static List<DTOMovimientoTipo> ToListadoSimpleDTO(List<MovimientoTipo> tipos) 
        {
            return tipos.Select(tipos => ToDTOMovimientoTipo(tipos)).ToList();
        }
    }
}
