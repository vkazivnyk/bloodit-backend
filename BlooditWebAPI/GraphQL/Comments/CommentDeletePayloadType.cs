using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentDeletePayloadType : ObjectType<CommentDeletePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentDeletePayload> descriptor)
        {
            descriptor.Description("Represents the payload type for deleting a post comment.");

            base.Configure(descriptor);
        }
    }
}
