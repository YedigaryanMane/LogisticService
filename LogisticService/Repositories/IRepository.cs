using System.Collections.Generic;

namespace LogisticService.Repositories
{
    public interface IRepository<TModel, TRequest>
    {
        void Add(TModel t);
        void Update(TModel t, int id);
        void Delete(int id);
        List<TModel> GetAll();
        TModel GetById(int id);
        TModel Find(TRequest request);
    }
}
