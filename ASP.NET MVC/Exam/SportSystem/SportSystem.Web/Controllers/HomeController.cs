using AutoMapper;
using SportSystem.Data.UnitOfWork;
using SportSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SportSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var bestTeams = this.Data.Teams
                .All()
                .OrderByDescending(m => m.Votes.Count)
                .Take(3);

            var bestMatches = this.Data.Matches
                .All()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .OrderByDescending(m => m.Bets.Count)
                .Take(3);

            var model = new HomeViewModel()
            {
                BestMatches = Mapper.Map<IEnumerable<MatchViewModel>>(bestMatches),
                BestTeams = Mapper.Map<IEnumerable<TeamViewModel>>(bestTeams)
            };

            return View(model);
        }
    }
}