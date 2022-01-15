using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentAddInputType : InputObjectType<CommentAddInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CommentAddInput> descriptor)
        {
            descriptor.Description("Represents the input type for a new post comment.");

            base.Configure(descriptor);
        }
    }
}
