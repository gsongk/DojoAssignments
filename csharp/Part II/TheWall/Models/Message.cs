using System.ComponentModel.DataAnnotations;
namespace TheWall.Models
{
    public class Message
    {
        [Display(Name = "Message")]
        [Required]
        public string MessageContent { get; set; }
    }
    public class Comment
    {
        [Display(Name = "Comment on this Post")]
        [Required]
        public string CommentContent { get; set; }
        public int MessageId { get; set; }
    }

    public class WallModels
    {
        public Message MessagePost { get; set; }
        public Comment CommentPost { get; set; }
    }
}