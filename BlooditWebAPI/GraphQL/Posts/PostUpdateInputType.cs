using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Posts
{
    public class PostUpdateInputType : ObjectType<PostUpdateInput>
    {
        protected override void Configure(IObjectTypeDescriptor<PostUpdateInput> descriptor)
        {
            descriptor.Description("Represents the input type for updating a post.");

            base.Configure(descriptor);
        }
    }
}
