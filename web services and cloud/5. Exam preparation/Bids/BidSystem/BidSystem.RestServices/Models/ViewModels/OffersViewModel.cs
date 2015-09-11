using BidSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BidSystem.RestServices.Models.ViewModels
{
    public class OffersViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Seller { get; set; }

        public DateTime DatePublished { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDateTime { get; set; }

        public bool IsExpired { get; set; }

        public int BidsCount { get; set; }

        public string BidWinner { get; set; }

        public static Expression<Func<Offer, OffersViewModel>> Create
        {
            get
            {
                return o => new OffersViewModel
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Seller = o.Seller.UserName,
                    DatePublished = o.PublishDate,
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDate,
                    IsExpired = DateTime.Now > o.ExpirationDate,
                    BidsCount = o.Bids.Count,
                    BidWinner = o.Bids.Count > 0 && DateTime.Now > o.ExpirationDate ?
                        o.Bids.OrderByDescending(b => b.Price).Select(b => b.Bidder.UserName).FirstOrDefault() : null
                };
            }
        }
    }
}