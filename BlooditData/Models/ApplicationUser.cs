using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlooditData.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<UserTopic> UserTopics { get; set; } = new List<UserTopic>();

        public IEnumerable<Post> Posts { get; set; } = new List<Post>();

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
