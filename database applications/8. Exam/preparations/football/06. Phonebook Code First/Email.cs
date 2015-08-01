namespace football
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}