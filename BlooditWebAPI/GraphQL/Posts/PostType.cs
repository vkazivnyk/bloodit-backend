using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Represents the type for a user post.");

            // TODO: add resolvers

            base.Configure(descriptor);
        }
    }
}
