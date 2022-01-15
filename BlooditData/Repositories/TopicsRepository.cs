using BlooditData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlooditData.Repositories
{
    public sealed class TopicsRepository : IRepository<Topic>
    {
        public Topic Create(Topic value)
        {
            throw new NotImplementedException();
        }

        public Topic Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Topic Update(Topic value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> Where(Func<Topic, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
