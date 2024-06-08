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
            return new Usuario()
            {
                id = usuario.Id,
                nombre = usuario.Nombre,
                apellido = usuario.Apellido,
                email = usuario.Email,
                password = usuario.Password,
            };
        }

        public static DTOUsuario ToDTOUsuario(Usuario usuario)
        {

            if (usuario != null)
            {
                return new DTOUsuario()
                {
                    Id = usuario.id,
                    Nombre = usuario.nombre,
                    Apellido = usuario.apellido,
                    Email = usuario.email,
                    Password = usuario.passwordHash
                };
            }
            return null;
        }

        public static List<DTOUsuario> ToListadoUsuarioDTO(List<Usuario> usuarios)
        {
            return usuarios.Select(usuario => ToDTOUsuario(usuario)).ToList();
        }
    }
}
