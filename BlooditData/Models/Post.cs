using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlooditData.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public string TopicId { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Dislikes { get; set; }

        public virtual List<Comment> Comments { get; set; } = new();

        public virtual ApplicationUser User { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
