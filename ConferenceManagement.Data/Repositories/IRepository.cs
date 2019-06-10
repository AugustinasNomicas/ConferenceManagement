using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceManagement.Data.Repositories
{
    public interface IRepository<T>
    {
        int Add(T entity);
        void Delete(int id);
        IEnumerable<T> Get();
        T GetBy(int id);
        void Update(T entity);
    }
}
