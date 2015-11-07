using System;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public virtual Snippet Snippet { get; set; }
    }
}
