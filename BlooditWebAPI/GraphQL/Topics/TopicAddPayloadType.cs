using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Topics
{
    public class TopicAddPayloadType : ObjectType<TopicAddPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<TopicAddPayload> descriptor)
        {
            descriptor.Description("Represents the payload type for a new topic");

            base.Configure(descriptor);
        }
    }
}
