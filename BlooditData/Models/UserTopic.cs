using System.ComponentModel.DataAnnotations;

namespace BlooditData.Models
{
    public class UserTopic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TopicId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Topic Topic { get; set; }
    }
}
