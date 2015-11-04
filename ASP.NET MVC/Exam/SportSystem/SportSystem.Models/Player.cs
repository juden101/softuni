namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Height { get; set; }

        public virtual Team Team { get; set; }
    }
}