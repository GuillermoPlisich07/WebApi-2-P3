using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioMovimientoStock : IRepositorioMovimientoStock
    {
        public DBContext Contexto { get; set; }

        public RepositorioMovimientoStock(DBContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(MovimientoStock item)
        {
            if (item != null)
            {
                Contexto.MovimientosStock.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<MovimientoStock> FindAll()
        {
            return Contexto.MovimientosStock.ToList();
        }

        public MovimientoStock FindById(int id)
        {
            return Contexto.MovimientosStock
                .Where(mov => mov.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            MovimientoStock aBorrar = Contexto.MovimientosStock.Find(id);
            if (aBorrar != null)
            {
                Contexto.MovimientosStock.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(MovimientoStock obj)
        {
            throw new NotImplementedException();
        }
    }
}
