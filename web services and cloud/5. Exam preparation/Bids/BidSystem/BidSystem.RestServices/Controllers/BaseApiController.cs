using BidSystem.Data;
using BidSystem.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BidSystem.RestServices.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new BidSystemData(new BidSystemDbContext()))
        {
        }

        public BaseApiController(IBidSystemData data)
        {
            this.Data = data;
        }

        protected IBidSystemData Data { get; set; }
    }
}