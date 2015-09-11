using BidSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BidSystem.RestServices.Models.ViewModels
{
    public class DetailedOfferViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Seller { get; set; }

        public DateTime DatePublished { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDateTime { get; set; }

        public bool IsExpired { get; set; }

        public string BidWinner { get; set; }

        public IEnumerable<BidsViewModel> Bids { get; set; }

        public static Expression<Func<Offer, DetailedOfferViewModel>> Create
        {
            get
            {
                return o => new DetailedOfferViewModel
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Seller = o.Seller.UserName,
                    DatePublished = o.PublishDate,
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDate,
                    IsExpired = DateTime.Now > o.ExpirationDate,
                    BidWinner = o.Bids.Count > 0 && DateTime.Now > o.ExpirationDate ?
                        o.Bids.OrderByDescending(b => b.Price).Select(b => b.Bidder.UserName).FirstOrDefault() : null,
                    Bids = o.Bids.OrderByDescending(b => b.Date).AsQueryable().Select(BidsViewModel.Create)
                };
            }
        }
    }
}