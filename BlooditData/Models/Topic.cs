using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlooditData.Models
{
    public class Topic
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public List<Post> Posts { get; set; } = new();

        public List<UserTopic> UserTopics { get; set; } = new();
    }
}
