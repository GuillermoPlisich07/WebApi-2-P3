using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperArticulo
    {
        public static Articulo ToArticulo(DTOArticulo articulo)
        {

            return new Articulo()
            {
                id = articulo.id,
                nombre = articulo.nombre,
                descripcion = articulo.descripcion,
                codigoProveedor = articulo.codigoProveedor,
                precioPublico = articulo.precioPublico,
                stock = articulo.stock,

            };
        }

        public static DTOArticulo ToDTOArticulo(Articulo articulo)
        {

            return new DTOArticulo()
            {
                id = articulo.id,
                nombre = articulo.nombre,
                descripcion = articulo.descripcion,
                codigoProveedor = articulo.codigoProveedor,
                precioPublico = articulo.precioPublico,
                stock = articulo.stock
            };
        }
        public static List<DTOArticulo> ToListadoSimpleDTO(List<Articulo> articulos)
        {
            return articulos.Select(articulos => ToDTOArticulo(articulos)).ToList();
        }

        public static List<DTOArticulo> ToListadoOrdenado(List<Articulo> articulos)
        {
            return articulos.OrderBy(articulo => articulo.nombre).Select(articulo => ToDTOArticulo(articulo)).ToList();
        }
    }
}
