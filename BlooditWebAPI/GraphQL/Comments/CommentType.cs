using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Description("Represents the type for a post comment.");

            // TODO: add resolvers

            base.Configure(descriptor);
        }
    }
}
