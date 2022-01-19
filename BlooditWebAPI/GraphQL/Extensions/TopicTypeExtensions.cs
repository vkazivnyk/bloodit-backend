using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Extensions
{
    [ExtendObjectType(nameof(Topic))]
    public class TopicTypeExtensions
    {
        public IEnumerable<ApplicationUser> GetUser([Parent] Topic topic, [Service] IAppRepository repository)
        {
            return repository.GetUsersByTopicId(topic.Id);
        }

        public int GetSubscriberCount([Parent] Topic topic, [Service] IAppRepository repository)
        {
            return repository.GetUsersByTopicId(topic.Id).Count();
        }
    }
}
