using SportSystem.Data;
using SportSystem.Data.UnitOfWork;
using SportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        private ISportSystemData data;
        private ApplicationUser userProfile;

        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        protected BaseController(ISportSystemData data, ApplicationUser userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ISportSystemData Data { get; private set; }

        protected ApplicationUser UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}