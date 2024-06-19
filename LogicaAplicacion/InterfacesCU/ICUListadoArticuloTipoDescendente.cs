using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUListadoArticuloTipoDescendente <T>
    {
        List<T> ObtenerListado(int idArticulo, int idTipo, int pagina, int cantXPagina);
    }
}
