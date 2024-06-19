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
    public class CUListadoAnualesPorTipo : ICUListadoAnualesPorTipo<DTOResumenAnio>
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUListadoAnualesPorTipo(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public List<DTOResumenAnio> ObtenerListado()
        {
            return MapperMovimientoStock.ToListadoResumenDTO(Repo.GetResumenAnualesPorTipo());
        }
    }
}
