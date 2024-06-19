using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioMovimientoStock
    {
        void Add(MovimientoStock item);
        List<MovimientoStock> FindAll();
        MovimientoStock FindById(int id);
        List<MovimientoStock> GetArticuloAndTipoDecending(int idArticulo, int idTipo, int pagina, int cantXPagina);
        List<MovimientoStock> GetArticuloPorRangoDeFechas(DateTime inicio, DateTime final, List<int> idArticulos, int pagina, int cantXPagina);
        List<ResumenAnio> GetResumenAnualesPorTipo();

    }
}
