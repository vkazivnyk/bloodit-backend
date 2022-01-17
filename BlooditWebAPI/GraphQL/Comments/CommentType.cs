using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Description("Represents the type for a post comment.");

            descriptor
                .Field(c => c.User)
                .ResolveWith<Resolvers>(r => r.GetUser(default!, default!));

            descriptor
                .Field(c => c.Post)
                .ResolveWith<Resolvers>(r => r.GetPost(default!, default!));

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public ApplicationUser GetUser(Comment comment, [Service] IAppRepository repository)
            {
                return repository.GetUserByCommentId(comment.Id);
            }

            public Post GetPost(Comment comment, [Service] IAppRepository repository)
            {
                return repository.GetPostByCommentId(comment.Id);
            }
        }
    }
}
