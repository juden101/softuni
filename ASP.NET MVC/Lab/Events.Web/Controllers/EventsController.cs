using Events.Models;
using Events.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Events.Web.Extensions;

namespace Events.Web.Controllers
{
    [Authorize]
    public class EventsController : BaseController
    {
        public ActionResult My()
        {
            string currentUsereId = this.User.Identity.GetUserId();
            var events = this.db.Events
                .Where(e => e.AuthorId == currentUsereId)
                .OrderBy(e => e.StartDateTime)
                .Select(EventViewModel.Create);

            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);

            return View(new UpcomingPassedEventsViewModel()
            {
                UpcomingEvents = upcomingEvents,
                PassedEvents = passedEvents
            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };

                this.db.Events.Add(e);
                this.db.SaveChanges();
                this.AddNotification("Event created.", NotificationType.INFO);

                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = this.EventLoad(id);

            if (eventToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);

                return this.RedirectToAction("My");
            }

            return this.View(new EventBindingModel
            {
                Title = eventToEdit.Title,
                StartDateTime = eventToEdit.StartDateTime,
                Duration = eventToEdit.Duration,
                Description = eventToEdit.Description,
                Location = eventToEdit.Location,
                IsPublic = eventToEdit.IsPublic
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventBindingModel model)
        {
            var eventToEdit = this.EventLoad(id);

            if (eventToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);

                return this.RedirectToAction("My");
            }

            if (model != null && this.ModelState.IsValid)
            {
                eventToEdit.Title = model.Title;
                eventToEdit.StartDateTime = model.StartDateTime;
                eventToEdit.Duration = model.Duration;
                eventToEdit.Description = model.Description;
                eventToEdit.Location = model.Location;
                eventToEdit.IsPublic = model.IsPublic;

                this.db.SaveChanges();
                this.AddNotification("Event edited.", NotificationType.INFO);

                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        private Event EventLoad(int id)
        {
            string currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventToEdit = this.db.Events
                .Where(e => e.Id == id)
                .FirstOrDefault(e => e.AuthorId == currentUserId || isAdmin);

            return eventToEdit;
        }
    }
}