using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioMovimientoTipo : IRepositorioMovimientoTipo
    {
        public DBContext Contexto { get; set; }

        public RepositorioMovimientoTipo(DBContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(MovimientoTipo item)
        {
            throw new NotImplementedException();
        }

        public List<MovimientoTipo> FindAll()
        {
            return Contexto.MovimientosTipo.ToList();
        }

        public MovimientoTipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MovimientoTipo obj)
        {
            throw new NotImplementedException();
        }
    }
}
