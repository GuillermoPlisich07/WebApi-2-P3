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
    public class CUAltaMovimientoStock : ICUAlta<DTOMovimientoStock>
    {
        public IRepositorioMovimientoStock Repo { get; set; }

        public CUAltaMovimientoStock(IRepositorioMovimientoStock repo)
        {
            Repo = repo;
        }

        public void Alta(DTOMovimientoStock nuevo)
        {
            MovimientoStock tipo = MapperMovimientoStock.ToMovimientoStock(nuevo);
            Repo.Add(tipo);
        }
    }
}
