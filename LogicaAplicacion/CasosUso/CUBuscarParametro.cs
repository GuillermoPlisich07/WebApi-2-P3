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
    public class CUBuscarParametro : ICUBuscarPorId<DTOParametro>
    {

        public IRepositorioParametro Repo { get; set; }
        public CUBuscarParametro(IRepositorioParametro repo) 
        {
            Repo = repo;
        }

        public DTOParametro Buscar(int id)
        {
            return MapperParametro.ToDTOParametro(Repo.FindById(id));
        }
    }
}
