using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesDominio
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException() : base()
        {

        }

        public DatosInvalidosException(string mensaje) : base(mensaje)
        {

        }

        public DatosInvalidosException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
