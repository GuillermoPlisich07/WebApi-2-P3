using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Articulo : IValidable
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public long codigoProveedor { get; set; }

        public decimal precioPublico { get; set; }

        public int stock { get; set; }

        public void Validar()
        {
            // TODO
        }
    }
}
