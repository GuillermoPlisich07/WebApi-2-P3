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
    public class CUListadoArticulo : ICUListado<DTOArticulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUListadoArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }
        public List<DTOArticulo> ObtenerListado()
        {
            return MapperArticulo.ToListadoSimpleDTO(Repo.FindAll());
        }
    }
}
