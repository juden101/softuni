using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Web.Models.ViewModels;

namespace Twitter.Web.Controllers
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = Data.ApplicationUsers.GetById(loggedUserId);

            var notifications = user
                .ReceivedNotifications
                .OrderByDescending(n => n.CreatedAt)
                .AsQueryable()
                .Select(NotificationViewModel.Create);

            return View(notifications);
        }
    }
}