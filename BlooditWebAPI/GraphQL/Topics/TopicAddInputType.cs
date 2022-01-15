using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Topics
{
    public class TopicAddInputType : InputObjectType<TopicAddInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TopicAddInput> descriptor)
        {
            descriptor.Description("Represents the input type for a new topic.");

            base.Configure(descriptor);
        }
    }
}
