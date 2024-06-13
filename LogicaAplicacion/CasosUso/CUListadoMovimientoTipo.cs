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
    public class CUListadoMovimientoTipo : ICUListado<DTOMovimientoTipo>
    {
        public IRepositorioMovimientoTipo Repo { get; set; }

        public CUListadoMovimientoTipo(IRepositorioMovimientoTipo repo)
        {
            Repo = repo;
        }

        public List<DTOMovimientoTipo> ObtenerListado()
        {
            return MapperMovimientoTipo.ToListadoSimpleDTO(Repo.FindAll());
        }
    }
}
