using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Comments
{
    public class CommentUpdatePayloadType : ObjectType<CommentUpdatePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentUpdatePayload> descriptor)
        {
            descriptor.Description("Represents the payload type for updating a post comment.");

            base.Configure(descriptor);
        }
    }
}
