using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using BlooditWebAPI.GraphQL.Users;
using HotChocolate;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Extensions
{
    [ExtendObjectType(nameof(ApplicationUser))]
    public class ApplicationUserTypeExtensions
    {
        public IEnumerable<Topic> GetTopic([Parent] ApplicationUser user, [Service] IAppRepository repository)
        {
            return repository.GetTopicsByUserId(user.Id);
        }
    }
}
