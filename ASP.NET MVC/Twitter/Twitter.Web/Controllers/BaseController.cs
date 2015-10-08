using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(ITwitterSystemData data)
        {
            this.Data = data;
        }

        protected ITwitterSystemData Data { get; }
    }
}