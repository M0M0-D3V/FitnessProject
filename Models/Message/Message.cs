using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required(ErrorMessage = "Message needs a title")]
        [Display(Name = "Subject:")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Message needs a body")]
        [Display(Name = "Message:")]
        public string Content { get; set; }
        public bool isRead { get; set; }
        public string MessageFromId { get; set; }
        public User MessageFrom { get; set; }
        [Display(Name = "Message To:")]
        public string UserMessagedId { get; set; }
        public User UserMessaged { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}