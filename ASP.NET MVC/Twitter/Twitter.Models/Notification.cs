namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public NotificationType Type { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        
        public virtual ApplicationUser Receiver { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}