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
    public class CUListadoUsuario : ICUListado<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUListadoUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public List<DTOUsuario> ObtenerListado()
        {
            return MapperUsuario.ToListadoUsuarioDTO(Repo.FindAll());

        }
    }
}
