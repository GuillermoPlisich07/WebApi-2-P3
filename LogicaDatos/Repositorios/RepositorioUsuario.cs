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
        public void Add(Usuario item)
        {
            if (item != null)
            {
                item.EncriptarPassword();
                Contexto.Usuarios.Add(item);
                Contexto.SaveChanges(); // Aca es el alta en EF
            }
        }

        public List<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios
                .Where(Usuario => Usuario.id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Usuario aBorrar = Contexto.Usuarios.Find(id);
            if (aBorrar != null)
            {
                Contexto.Usuarios.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Usuario obj)
        {
            // Verificar si el campo passwordHash si es vacio y es nulo
            if (string.IsNullOrEmpty(obj.password))
            {
                // Actualizar todos los campos excepto passwordHash
                Contexto.Entry(obj).State = EntityState.Modified;
                Contexto.Entry(obj).Property(u => u.passwordHash).IsModified = false;
            }
            else
            {
                obj.EncriptarPassword();
                Contexto.Usuarios.Update(obj);
            }

            Contexto.SaveChanges();
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
                .Where(Usuario => Usuario.email == email)
                .SingleOrDefault();
        }
    }
}
