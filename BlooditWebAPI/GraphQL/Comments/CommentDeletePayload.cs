using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlooditData.Models;

namespace BlooditWebAPI.GraphQL.Comments
{
    public record CommentDeletePayload(Comment Comment);
}
