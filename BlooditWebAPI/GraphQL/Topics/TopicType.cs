using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Topics
{
    public class TopicType : ObjectType<Topic>
    {
        protected override void Configure(IObjectTypeDescriptor<Topic> descriptor)
        {
            descriptor.Description("Represents the type for a topic.");

            // TODO: add resolvers

            base.Configure(descriptor);
        }
    }
}
