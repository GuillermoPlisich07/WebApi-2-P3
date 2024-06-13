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
    public class CUModificarMovimienoTipo : ICUModificar<DTOMovimientoTipo>
    {
        public IRepositorioMovimientoTipo Repo { get; set; }

        public CUModificarMovimienoTipo(IRepositorioMovimientoTipo repo)
        {
            Repo = repo;
        }

        public void Modificar(DTOMovimientoTipo Tipo)
        {
            Repo.Update(MapperMovimientoTipo.ToMovimientoTipo(Tipo));
        }
    }
}
