namespace Events.Web.Models
{
    using Events.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class EventDetailsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Event, EventDetailsViewModel>> Create
        {
            get
            {
                return e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Description = e.Description,
                    Comments = e.Comments.AsQueryable().Select(CommentViewModel.Create),
                    AuthorId = e.AuthorId
                };
            }
        }
    }
}