using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaMovimientoTipo : ICUBaja
    {
       public IRepositorioMovimientoTipo Repo { get; set; }

        public CUBajaMovimientoTipo(IRepositorioMovimientoTipo repo)
        {
            Repo = repo;
        }

        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
