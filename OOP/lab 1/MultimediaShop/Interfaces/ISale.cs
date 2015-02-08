namespace MultimediaShop.Interfaces
{
    using System;
    using MultimediaShop.Models;

    public interface ISale
    {
        Item Item { get; set; }
        DateTime DateOfPurchase { get; set; }
    }
}