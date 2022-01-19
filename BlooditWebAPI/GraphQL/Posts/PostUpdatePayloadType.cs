using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostUpdatePayloadType : ObjectType<PostUpdatePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<PostUpdatePayload> descriptor)
        {
            descriptor.Description("Represents the payload type for updating a post.");

            base.Configure(descriptor);
        }
    }
}
