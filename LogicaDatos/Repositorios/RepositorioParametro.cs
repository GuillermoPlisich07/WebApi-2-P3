using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioParametro : IRepositorioParametro
    {
        public DBContext Contexto { get; set; }

        public RepositorioParametro(DBContext ctx)
        {
            Contexto = ctx;
        }
        public void Update(Parametro obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        public Parametro FindById(int id)
        {
            return Contexto.Parametros
               .Where(pa => pa.id == id)
               .SingleOrDefault();
        }
    }
}
