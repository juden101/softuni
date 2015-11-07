namespace Snippy.Web.Controllers
{
    using System;
    using System.Linq;
    using Data.UnitOfWork;
    using System.Web.Mvc;
    using Models;
    using Snippy.Models;

    public class HomeController : BaseController
    {
        public HomeController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var lastSnippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreatedOn)
                .Take(5);

            var lastComments = this.Data.Comments.All()
                .OrderByDescending(s => s.CreatedOn)
                .Take(5);

            var bestLabels = this.Data.Labels.All()
                .OrderByDescending(s => s.Snippets.Count)
                .ThenBy(s => s.Text)
                .Take(5);

            var model = new HomeViewModel()
            {
                LastSnippets = lastSnippets.Select(SnippetViewModel.Create),
                LastComments = lastComments.Select(ShortCommentViewModel.Create),
                BestLabels = bestLabels.Select(LabelViewModel.Create)
            };

            return View(model);
        }
    }
}