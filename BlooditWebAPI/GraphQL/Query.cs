using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;
using HotChocolate.Data;

namespace BlooditWebAPI.GraphQL
{
    [GraphQLDescription("Represents type queries.")]
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Represents the query for retrieving users.")]
        public IEnumerable<ApplicationUser> GetUser([Service] IAppRepository repository)
        {
            return repository.GetUsers();
        }

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Represents the query for retrieving posts.")]
        public IEnumerable<Post> GetPost([Service] IAppRepository repository)
        {
            return repository.GetPosts();
        }

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Represents the query for retrieving topics.")]
        public IEnumerable<Topic> GetTopic([Service] IAppRepository repository)
        {
            return repository.GetTopics();
        }

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Represents the query for retrieving comments.")]
        public IEnumerable<Comment> GetComment([Service] IAppRepository repository)
        {
            return repository.GetComments();
        }
    }
}
