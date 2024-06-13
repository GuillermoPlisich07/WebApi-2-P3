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
    public class CUBuscarMovimientoTipo : ICUBuscarPorId<DTOMovimientoTipo>
    {
        public IRepositorioMovimientoTipo Repo { get; set; }

        public CUBuscarMovimientoTipo(IRepositorioMovimientoTipo repo)
        {
            Repo = repo;
        }

        public DTOMovimientoTipo Buscar(int id)
        {
            return MapperMovimientoTipo.ToDTOMovimientoTipo(Repo.FindById(id));
        }
    }
}
