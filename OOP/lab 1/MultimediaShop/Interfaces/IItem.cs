namespace MultimediaShop.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IItem
    {
        string Id { get; set; }
        string Title { get; set; }
        double Price { get; set; }
        IEnumerable<string> Genres { get; set; }
    }
}
