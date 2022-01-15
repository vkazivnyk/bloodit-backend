using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlooditWebAPI.GraphQL.Posts
{
    public record PostAddInput(string TopicId, string Heading, string Body);
}
