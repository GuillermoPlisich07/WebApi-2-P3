using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario
    {
        Usuario Login(string email, string password);
        Usuario FindByEmail(string email);
        List<Usuario> FindAll();
        Usuario FindById(int id);
    }
}
