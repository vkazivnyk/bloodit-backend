using System;
using System.ComponentModel.DataAnnotations;

namespace BlooditData.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public string PostId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Dislikes { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Post Post { get; set; }
    }
}
