using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class MovimientoStock : IValidable
    {
        public int id { get; set; }
        public DateTime fechaDeMovimiento { get; set; }
        public Articulo articulo { get; set; }
        public MovimientoTipo tipo { get; set; }
        public Usuario usuario { get; set; }
        public int topeMovimiento { get; set; }
        public int cantidadMovidas { get; set; }

        public void Validar()
        {
            //TODO
        }
    }
}
