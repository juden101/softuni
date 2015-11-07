using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Models
{
    public class Snippet
    {
        private ICollection<Label> labels;
        private ICollection<Comment> comments;

        public Snippet()
        {
            this.labels = new HashSet<Label>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public virtual ProgrammingLanguage Language { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Label> Labels
        {
            get { return this.labels; }
            set { this.labels = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
