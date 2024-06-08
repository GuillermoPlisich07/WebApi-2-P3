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
    public class CUBuscarUsuario : ICUBuscarPorId<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBuscarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public DTOUsuario Buscar(int id)
        {
            return MapperUsuario.ToDTOUsuario(Repo.FindById(id));
        }
    }
}
