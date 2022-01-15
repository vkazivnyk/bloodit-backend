using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentDeleteInputType : InputObjectType<CommentDeleteInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CommentDeleteInput> descriptor)
        {
            descriptor.Description("Represents the input type for deleting a post comment.");

            base.Configure(descriptor);
        }
    }
}
