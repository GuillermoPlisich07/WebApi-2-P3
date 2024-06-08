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
    public class CUAltaUsuario : ICUAlta<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Alta(DTOUsuario nuevo)
        {
            Repo.Add(MapperUsuario.ToUsuario(nuevo));
        }
    }
}
