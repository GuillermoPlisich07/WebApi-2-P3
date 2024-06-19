using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperParametro
    {
        public static Parametro ToParametro(DTOParametro parametro)
        {
            if (parametro == null) return null;
            return new Parametro()
            {
                id = parametro.id,
                topeMovimiento = parametro.topeMovimiento,
                topePaginado = parametro.topePaginado
            };
        }

        public static DTOParametro ToDTOParametro(Parametro parametro)
        {
            if (parametro == null) return null;
            return new DTOParametro()
            {
                id = parametro.id,
                topeMovimiento = parametro.topeMovimiento,
                topePaginado = parametro.topePaginado
            };

        }
    }
}
