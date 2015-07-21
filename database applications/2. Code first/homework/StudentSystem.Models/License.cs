namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class License
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}