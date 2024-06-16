using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOMovimientoStockVista
    {
        public int id {  get; set; }
        public int idArticulo {  get; set; }
        public int idMovimientoTipo { get; set; }
        public string email { get; set; }
        public int cantidadMovidas { get; set; }
    }
}
