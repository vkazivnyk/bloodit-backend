using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentUpdateInputType : InputObjectType<CommentUpdateInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CommentUpdateInput> descriptor)
        {
            descriptor.Description("Represents the input type for updating a post comment.");

            base.Configure(descriptor);
        }
    }
}
