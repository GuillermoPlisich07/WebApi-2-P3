using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuario
    {
        public static Usuario ToUsuario(DTOUsuario usuario)
        {
            if (usuario == null) return null;
            return new Usuario()
            {
                id = usuario.Id,
                nombre = usuario.Nombre,
                apellido = usuario.Apellido,
                email = usuario.Email,
                password = usuario.Password,
                rol = MapperRol.ToRol(usuario.rol)
            };
        }

        public static DTOUsuario ToDTOUsuario(Usuario usuario)
        {
            if (usuario == null) return null;
            return new DTOUsuario()
            {
                Id = usuario.id,
                Nombre = usuario.nombre,
                Apellido = usuario.apellido,
                Email = usuario.email,
                Password = usuario.passwordHash,
                rol = MapperRol.ToDTORol(usuario.rol)
            };
        }

        public static List<DTOUsuario> ToListadoUsuarioDTO(List<Usuario> usuarios)
        {
            return usuarios.Select(usuario => ToDTOUsuario(usuario)).ToList();
        }
    }
}
