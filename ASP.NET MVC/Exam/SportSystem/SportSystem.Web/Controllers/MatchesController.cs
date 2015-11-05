using SportSystem.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SportSystem.Web.Models;
using AutoMapper;

namespace SportSystem.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using SportSystem.Models;

    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1, int count = 5)
        {
            var matches = this.Data.Matches.All();
            int matchesCount = matches.Count();

            matches = matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .OrderBy(m => m.DateAndTime)
                .Skip((page - 1) * count)
                .Take(count);

            this.ViewBag.TotalPages = (matchesCount + count - 1) / count;
            this.ViewBag.CurrentPage = page;

            var model = Mapper.Map<IEnumerable<MatchViewModel>>(matches);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var match = this.Data.Matches
                .All()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.Id == id)
                .Project()
                .To<DetailedMatchViewModel>()
                .FirstOrDefault();

            if (match == null)
            {
                return HttpNotFound();
            }

            var comments = this.Data.Comments.All().Where(c => c.Match.Id == match.Id);

            var model = new DetailedMatchViewModel()
            {
                Comments = Mapper.Map<ICollection<CommentViewModel>>(comments)
            };

            return View(match);
        }
    }
}