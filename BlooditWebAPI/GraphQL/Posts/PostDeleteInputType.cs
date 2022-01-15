using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostDeleteInputType : InputObjectType<PostDeleteInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PostDeleteInput> descriptor)
        {
            descriptor.Description("Represents the input type for deleting a user post.");

            base.Configure(descriptor);
        }
    }
}
