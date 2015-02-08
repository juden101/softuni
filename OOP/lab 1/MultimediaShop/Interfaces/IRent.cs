namespace MultimediaShop.Interfaces
{
    using System;
    using MultimediaShop.Models;

    public interface IRent
    {
        Item Item { get; set; }
        ItemRentState RentState { get; set; }
        DateTime DateOfRent { get; set; }
        DateTime Deadline { get; set; }
        DateTime DateOfReturn { get; set; }

        double CalculateTheRentFine();
    }

    enum ItemRentState
    {
        Returned,
        Overdue
    }
}
