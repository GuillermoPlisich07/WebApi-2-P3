using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoAnualesPorTipo : ICUListadoAnualesPorTipo<DTOMovimientoStock>
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUListadoAnualesPorTipo(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public List<DTOMovimientoStock> ObtenerListado()
        {
            return MapperMovimientoStock.ToListadoSimpleDTO(Repo.GetResumenAnualesPorTipo());
        }
    }
}
