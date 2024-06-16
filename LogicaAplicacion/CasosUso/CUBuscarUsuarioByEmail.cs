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
    public class CUBuscarUsuarioByEmail : ICUBuscarByEmail<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBuscarUsuarioByEmail(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public DTOUsuario BuscarByEmail(string email)
        {
            return MapperUsuario.ToDTOUsuario(Repo.FindByEmail(email));
        }
    }
}
