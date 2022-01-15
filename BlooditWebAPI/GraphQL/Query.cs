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
        [GraphQLDescription("Represents the query for retrieving posts.")]
        public IEnumerable<Post> GetPost([Service] IAppRepository repository)
        {
            return repository.GetPosts();
        }
    }
}
