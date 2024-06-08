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
    public class CULoginUsuario : ICULogin<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CULoginUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public DTOUsuario loguearse(string email, string password)
        {
            return MapperUsuario.ToDTOUsuario(Repo.Login(email, password));
        }
    }
}
