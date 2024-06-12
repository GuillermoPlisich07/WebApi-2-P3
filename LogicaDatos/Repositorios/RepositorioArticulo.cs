using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        public DBContext Contexto { get; set; }

        public RepositorioArticulo(DBContext ctx)
        {
            Contexto = ctx;
        }


        public List<Articulo> FindAll()
        {
            return Contexto.Articulos.Where(ar => ar.stock > 0).ToList();
        }

        public Articulo FindById(int id)
        {
            return Contexto.Articulos
                .Where(ar => ar.id == id)
                .SingleOrDefault();
        }

        public void Update(Articulo obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

      
    }
}
