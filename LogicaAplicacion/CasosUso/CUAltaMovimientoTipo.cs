using DTOs;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaMovimientoTipo
    {
        IRepositorioMovimientoTipo Repo { get; set; }

        public CUAltaMovimientoTipo(IRepositorioMovimientoTipo repo)
        {
            Repo = repo;
        }

        public void Alta(DTOMovimientoTipo nuevo) 
        {
            MovimientoTipo tipo = MapperMovimientoTipo.ToMovimientoTipo(nuevo);
            Repo.Add(tipo);
        }
    }
}
