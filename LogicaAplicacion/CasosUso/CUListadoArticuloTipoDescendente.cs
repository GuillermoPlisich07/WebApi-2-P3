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
    public class CUListadoArticuloTipoDescendente : ICUListadoArticuloTipoDescendente<DTOMovimientoStock>
    {
        public IRepositorioMovimientoStock Repo { get; set; }
        public CUListadoArticuloTipoDescendente(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public List<DTOMovimientoStock> ObtenerListado(int idArticulo, int idTipo)
        {
            return MapperMovimientoStock.ToListadoSimpleDTO(Repo.GetArticuloAndTipoDecending(idArticulo,idTipo));
        }
    }
}
