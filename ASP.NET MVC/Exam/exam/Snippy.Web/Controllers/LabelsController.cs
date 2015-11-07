using Snippy.Data.UnitOfWork;
using Snippy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.Web.Controllers
{
    public class LabelsController : BaseController
    {
        public LabelsController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var labelViewModel = this.Data.Labels.All()
                .Where(l => l.Id == id)
                .Select(ShortLabelViewModel.Create)
                .FirstOrDefault();

            var label = this.Data.Labels.All()
                .Where(l => l.Id == id)
                .FirstOrDefault();

            if (label == null)
            {
                return HttpNotFound();
            }

            var model = new LabelPageViewModel()
            {
                Label = labelViewModel,
                Snippets = label.Snippets.AsQueryable().Select(ShortSnippetViewModel.Create)
            };

            return View(model);
        }
    }
}