using BugTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BugTracker.RestServices.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new BugTrackerDbContext())
        {
        }

        public BaseApiController(BugTrackerDbContext data)
        {
            this.Data = data;
        }

        protected BugTrackerDbContext Data { get; set; }
    }
}