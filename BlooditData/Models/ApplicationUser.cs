using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlooditData.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<UserTopic> UserTopics { get; set; } = new();

        public virtual List<Post> Posts { get; set; } = new();

        public virtual List<Comment> Comments { get; set; } = new();
    }
}
