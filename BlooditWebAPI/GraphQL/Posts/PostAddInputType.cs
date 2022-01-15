using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostAddInputType : InputObjectType<PostAddInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PostAddInput> descriptor)
        {
            descriptor.Description("Represents the input type for a new user post.");

            base.Configure(descriptor);
        }
    }
}
