using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Repositories
{
    public interface IRepository<TModel, TRequest>
    {
        void Add(TModel t);
        void Update(TModel t);
        void Delete(int id);
        List<TModel> GetAll();
        TModel GetById(int id);
        TModel Find(TRequest request);
    }
}
