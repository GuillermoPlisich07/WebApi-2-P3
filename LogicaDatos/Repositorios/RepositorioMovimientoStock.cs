﻿using Azure.Core;
using DTOs;
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


        public List<MovimientoStock> GetArticuloAndTipoDecending(int idArticulo, int idTipo, int pagina, int cantXPagina)
        {
            int numRegistrosAnteriores = cantXPagina * (pagina - 1);

            return Contexto.MovimientosStock
                .Include(m => m.articulo)
                .Include(m => m.tipo)
                .Include(m => m.usuario)
                    .ThenInclude(u => u.rol)
                .Where(m => m.articulo.id == idArticulo && m.tipo.id == idTipo)
                .OrderByDescending(m => m.fechaDeMovimiento)
                .ThenBy(m => m.cantidadMovidas)
                .Skip(numRegistrosAnteriores)
                .Take(cantXPagina)
                .ToList();
    }

        public List<MovimientoStock> GetArticuloPorRangoDeFechas(DateTime inicio, DateTime final, List<int> idArticulos, int pagina, int cantXPagina)
        {
            int numRegistrosAnteriores = cantXPagina * (pagina - 1);

            return Contexto.MovimientosStock
                .Include(m => m.articulo)
                .Include(m => m.tipo)
                .Include(m => m.usuario)
                    .ThenInclude(u => u.rol)
                .Where(m => idArticulos.Contains(m.articulo.id)
                            && m.fechaDeMovimiento >= inicio
                            && m.fechaDeMovimiento <= final)
                .Distinct()
                .Skip(numRegistrosAnteriores)
                .Take(cantXPagina)
                .ToList();
        }

        public List<ResumenAnio> GetResumenAnualesPorTipo()
        {
            return Contexto.MovimientosStock
                    .Include(m => m.tipo) // Para incluir el nombre del tipo de movimiento
                    .GroupBy(m => new { Anio = m.fechaDeMovimiento.Year, m.tipo.nombre }) // Agrupar por año y nombre del tipo de movimiento
                    .Select(g => new ResumenAnio
                    {
                        anio = g.Key.Anio,
                        tipo = g.Key.nombre,
                        cantMovidas = g.Sum(m => m.cantidadMovidas)
                    })
                    .OrderBy(r => r.anio)
                    .ThenBy(r => r.tipo)
                    .ToList();

        }
    }
}
