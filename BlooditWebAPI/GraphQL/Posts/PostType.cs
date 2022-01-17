using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Represents the type for a user post.");

            descriptor
                .Field(p => p.Comments)
                .ResolveWith<Resolvers>(r => r.GetComment(default!, default!));

            descriptor
                .Field(p => p.User)
                .ResolveWith<Resolvers>(r => r.GetUser(default!, default!));

            descriptor
                .Field(p => p.Topic)
                .ResolveWith<Resolvers>(r => r.GetTopic(default!, default!));

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public IEnumerable<Comment> GetComment(Post post, [Service] IAppRepository repository)
            {
                return repository.GetCommentsByPostId(post.Id);
            }

            public ApplicationUser GetUser(Post post, [Service] IAppRepository repository)
            {
                return repository.GetUserByPostId(post.Id);
            }

            public Topic GetTopic(Post post, [Service] IAppRepository repository)
            {
                return repository.GetTopicByPostId(post.Id);
            }
        }
    }
}
