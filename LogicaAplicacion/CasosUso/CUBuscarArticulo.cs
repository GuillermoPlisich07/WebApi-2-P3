﻿using DTOs;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarArticulo
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUBuscarArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }
        public DTOArticulo Buscar(int id)
        {
            return MapperArticulo.ToDTOArticulo(Repo.FindById(id));
        }
    }
}
