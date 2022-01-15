using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlooditData.Repositories
{
    public interface IRepository<T>
    {
        public Task SaveChangesAsync();

        public T Create(T value);

        public T Update(T value);

        public T Delete(string id);

        public IEnumerable<T> Where(Func<T, bool> predicate);

        public IEnumerable<T> GetAll();
    }
}
