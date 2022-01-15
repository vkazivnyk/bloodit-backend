using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostAddPayloadType : ObjectType<PostAddPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<PostAddPayload> descriptor)
        {
            descriptor.Description("Represents the payload type for a new user post.");

            base.Configure(descriptor);
        }
    }
}
