using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlooditWebAPI.GraphQL.Comments
{
    public record CommentAddInput(string AuthorId, string PostId, string Text);
}
