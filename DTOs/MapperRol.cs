using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperRol
    {
        public static Rol ToRol(DTORol rol)
        {
            if (rol == null) return null;
            return new Rol()
            {
                id = rol.id,
                nombre = rol.nombre

            };
        }

        public static DTORol ToDTORol(Rol rol)
        {
            if (rol == null) return null;
            return new DTORol() 
            {
                id = rol.id,
                nombre = rol.nombre
            };
        }
        public static List<DTORol> ToListadoSimpleDTO(List<Rol> rol)
        {
            return rol.Select(r => ToDTORol(r)).ToList();
        }
    }
}
