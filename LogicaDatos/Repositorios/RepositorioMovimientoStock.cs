using Azure.Core;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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
                var articulo = Contexto.Articulos.Find(item.articulo.id);
                var tipo = Contexto.MovimientosTipo.Find(item.tipo.id);
                var usuario = Contexto.Usuarios.Find(item.usuario.id);

                item.articulo = articulo;
                item.tipo = tipo;
                item.usuario = usuario;

                // No funciona correctamente
                //Contexto.Entry(item.usuario).State = EntityState.Unchanged;
                //Contexto.Entry(item.tipo).State = EntityState.Unchanged;
                //Contexto.Entry(item.articulo).State = EntityState.Unchanged;


                item.fechaDeMovimiento = DateTime.Now;
                Contexto.MovimientosStock.Add(item);
                Contexto.SaveChanges(); 
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


        public List<MovimientoStock> GetArticuloAndTipoDecending(int idArticulo, int idTipo)
        {
            return Contexto.MovimientosStock
                .Include(m => m.articulo)
                .Include(m => m.tipo)
                .Include(m => m.usuario)
                    .Where(m => m.articulo.id == idArticulo && m.tipo.id == idTipo)
                    .OrderByDescending(m => m.fechaDeMovimiento)
                    .ThenBy(m => m.cantidadMovidas)
                    .ToList();
        }

        public List<MovimientoStock> GetArticuloPorRangoDeFechas(DateTime inicio, DateTime final, List<int> idArticulos)
        {
            return Contexto.MovimientosStock
                .Include(m => m.articulo)
                .Include(m => m.tipo)
                .Include(m => m.usuario)
                   .Where(m => idArticulos.Contains(m.articulo.id)
                               && m.fechaDeMovimiento >= inicio
                               && m.fechaDeMovimiento <= final)
                   .Distinct()
                   .ToList();
        }

        public List<MovimientoStock> GetResumenAnualesPorTipo()
        {
            throw new NotImplementedException();
        }
    }
}
