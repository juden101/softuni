namespace News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public News()
        {
        }

        public News(string content)
        {
            this.Content = content;
        }

        [Key]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}