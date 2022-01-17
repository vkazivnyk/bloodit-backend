using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;
using BlooditData.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace BlooditWebAPI.GraphQL.Topics
{
    public class TopicType : ObjectType<Topic>
    {
        protected override void Configure(IObjectTypeDescriptor<Topic> descriptor)
        {
            descriptor.Description("Represents the type for a topic.");

            descriptor
                .Field(t => t.UserTopics)
                .Ignore();

            descriptor
                .Field(t => t.Posts)
                .Name("post")
                .ResolveWith<Resolvers>(r => r.GetPosts(default, default));

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public IEnumerable<Post> GetPosts(Topic topic, [Service] IAppRepository repository)
            {
                return repository.GetPostsByTopicId(topic.Id);
            }
        }
    }
}
