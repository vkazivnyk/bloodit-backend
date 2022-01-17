using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;

namespace BlooditWebAPI.GraphQL
{
    [GraphQLDescription("Represents user, topic, post & comment queries.")]
    public class Query
    {
        public IEnumerable<ApplicationUser> GetUser([Service] IAppRepository repository)
        {
            return repository.GetUsers();
        }

        [GraphQLDescription("Represents the query for retrieving posts.")]
        public IEnumerable<Post> GetPost([Service] IAppRepository repository)
        {
            return repository.GetPosts();
        }
    }
}
