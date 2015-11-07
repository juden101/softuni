using Snippy.Data.UnitOfWork;
using Snippy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.Web.Controllers
{
    public class LanguagesController : BaseController
    {
        public LanguagesController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var languageViewModel = this.Data.ProgrammingLanguages.All()
                .Where(l => l.Id == id)
                .Select(ShortLanguageViewModel.Create)
                .FirstOrDefault();

            var language = this.Data.ProgrammingLanguages.All()
                .Where(l => l.Id == id)
                .FirstOrDefault();

            if (language == null)
            {
                return HttpNotFound();
            }

            var model = new LanguagePageViewModel()
            {
                Language = languageViewModel,
                Snippets = language.Snippets.AsQueryable().Select(ShortSnippetViewModel.Create)
            };

            return View(model);
        }
    }
}