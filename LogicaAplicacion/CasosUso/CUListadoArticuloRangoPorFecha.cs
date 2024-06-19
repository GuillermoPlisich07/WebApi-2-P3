using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoArticuloRangoPorFecha : ICUListadoArticuloRangoPorFecha<DTOMovimientoStock>
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUListadoArticuloRangoPorFecha(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public List<DTOMovimientoStock> ObtenerListado(DateTime inicio, DateTime final, List<int> idArticulos, int pagina, int cantXPagina)
        {
            return MapperMovimientoStock.ToListadoSimpleDTO(Repo.GetArticuloPorRangoDeFechas(inicio, final,idArticulos, pagina, cantXPagina));
        }
    }
}
