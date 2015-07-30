namespace _05.EF_Code_First
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Mountain
    {
        public Mountain()
        {
            this.Peaks = new HashSet<Peak>();
            this.Countries = new HashSet<Country>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Peak> Peaks { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
