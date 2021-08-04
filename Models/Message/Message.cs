using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageFromId { get; set; }
        public User MessageFrom { get; set; }
        public string UserMessagedId { get; set; }
        public User UserMessaged { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}