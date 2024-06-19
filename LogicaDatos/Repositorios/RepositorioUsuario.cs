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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public DBContext Contexto { get; set; }

        public RepositorioUsuario(DBContext ctx)
        {
            Contexto = ctx;
        }

        public Usuario Login(string email, string password)
        {
            Usuario user = FindByEmail(email);

            //if (user != null && user.VerificarPassword(password))
            //{
            //    return user;
            //}
            if (user != null && user.passwordHash == password)
            {
                return user;
            }

            return null;
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios
                .Include(usu => usu.rol)
                .Where(usu => usu.email == email)
                .SingleOrDefault();
        }
     
    }
}
