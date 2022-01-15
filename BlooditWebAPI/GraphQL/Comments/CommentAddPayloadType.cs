using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentAddPayloadType : ObjectType<CommentAddPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentAddPayload> descriptor)
        {
            descriptor.Description("Represents the payload type for a new post comment.");

            base.Configure(descriptor);
        }
    }
}
