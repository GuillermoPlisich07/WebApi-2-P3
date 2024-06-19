using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUListadoArticuloRangoPorFecha <T>
    {
        List<T> ObtenerListado(DateTime inicio, DateTime final, List<int> idArticulos, int pagina, int cantXPagina);
    }
}
