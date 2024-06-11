using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOMovimientoStock
    {
        public int id {  get; set; }
        public List<DTOArticulo> articulos { get; set; }
        public int idArticulo {  get; set; }
        public List<DTOMovimientoTipo> tipos { get; set; }
        public int idMovimientoTipo { get; set; }
        public int idUsuario { get; set; }
        public int cantidadMovidas { get; set; }
    }
}
