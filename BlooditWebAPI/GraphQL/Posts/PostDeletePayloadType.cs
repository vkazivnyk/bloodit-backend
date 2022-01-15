using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostDeletePayloadType : ObjectType<PostDeletePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<PostDeletePayload> descriptor)
        {
            descriptor.Description("Represents the payload type for deleting a user post.");

            base.Configure(descriptor);
        }
    }
}
