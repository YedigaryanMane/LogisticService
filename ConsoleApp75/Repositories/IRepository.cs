using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Repositories
{
    public interface IRepository<T>
    {
        void Add(T t);
        void Update(T t);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
    internal class IRepository
    {
    }
}
