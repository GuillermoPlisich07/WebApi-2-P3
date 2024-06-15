using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOMovimientoStock
    {
        public int id { get; set; }
        public DateTime fechaDeMovimiento { get; set; }
        public DTOArticulo articulo { get; set; }
        public DTOMovimientoTipo tipo { get; set; }
        public DTOUsuario usuario { get; set; }
        public int cantidadMovidas { get; set; }
    }
}
