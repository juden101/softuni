using AutoMapper;
using SportSystem.Data.UnitOfWork;
using SportSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportSystem.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using SportSystem.Models;

    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var team = this.Data.Teams
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<DetailedTeamViewModel>()
                .FirstOrDefault();

            if (team == null)
            {
                return HttpNotFound();
            }

            var userId = this.User.Identity.GetUserId();
            team.UserHasVoted = this.Data.Votes.All().Any(x => x.Team.Id == id && x.UserId == userId);

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int teamId)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.Data.Votes.All().Any(x => x.Team.Id == teamId && x.UserId == userId))
            {
                var vote = new Vote()
                {
                    Team = this.Data.Teams.All().Where(t => t.Id == teamId).FirstOrDefault(),
                    VotingUser = this.Data.Users.All().Where(u => u.Id == userId).FirstOrDefault()
                };

                this.Data.Votes.Add(vote);
                this.Data.SaveChanges();

                var newVotes = this.Data.Votes.All().Where(x => x.Team.Id == teamId).Count();
                return this.Json(newVotes);
            }

            var votes = this.Data.Votes.All().Where(x => x.Team.Id == teamId).Count();
            return this.Json(votes);
        }
    }
}