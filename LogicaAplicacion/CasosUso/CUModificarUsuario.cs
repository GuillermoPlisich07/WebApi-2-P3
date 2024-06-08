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
    public class CUModificarUsuario : ICUModificar<DTOUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUModificarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Modificar(DTOUsuario t)
        {
            Repo.Update(MapperUsuario.ToUsuario(t));
        }
    }
}
