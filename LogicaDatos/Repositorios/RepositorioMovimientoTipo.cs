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
            if (item != null)
            {
                Contexto.MovimientosTipo.Add(item);
                Contexto.SaveChanges();
            }
        }

        public List<MovimientoTipo> FindAll()
        {
            return Contexto.MovimientosTipo.ToList();
        }

        public MovimientoTipo FindById(int id)
        {
            return Contexto.MovimientosTipo
                .Where(mt => mt.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            MovimientoTipo aBorrar = Contexto.MovimientosTipo.Find(id);
            if (aBorrar != null)
            {
                Contexto.MovimientosTipo.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(MovimientoTipo obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
