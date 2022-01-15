using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlooditData.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserTopic> UserTopics { get; set; } = new();

        public List<Post> Posts { get; set; } = new();

        public List<Comment> Comments { get; set; } = new();
    }
}
