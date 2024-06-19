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
    public class CULogin : ICULogin<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CULogin(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public DTOUsuario loguearse(string email, string password)
        {
            return MapperUsuario.ToDTOUsuario(Repo.Login(email, password));
        }
    }
}
