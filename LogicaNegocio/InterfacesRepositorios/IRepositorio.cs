using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio <T>
    {
        void Add(T item);

        void Remove(int id);

        void Update(T obj);

        List<T> FindAll();

        T FindById(int id);
    }
}
