using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOArticulo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [DisplayName("Codigo Proveedor")]
        public string CodigoProveedor { get; set; }

        [DisplayName("Precio Publico")]
        public decimal PrecioPublico { get; set; }

        public int Stock { get; set; }
    }
}
