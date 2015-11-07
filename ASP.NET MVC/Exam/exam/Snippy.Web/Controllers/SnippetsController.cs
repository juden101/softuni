using Microsoft.AspNet.Identity;
using Snippy.Data.UnitOfWork;
using Snippy.Models;
using Snippy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Snippy.Web.Controllers
{
    [ValidateInput(false)]
    public class SnippetsController : BaseController
    {
        private const int pageSize = 5;

        public SnippetsController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1)
        {
            var allSnippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreatedOn);

            var model = new SnippetPageViewModel()
            {
                Snippets = allSnippets.Skip((page - 1) * pageSize).Take(pageSize).Select(SnippetViewModel.Create),
                PageCount = allSnippets.Count() % pageSize == 0 ? allSnippets.Count() / pageSize : allSnippets.Count() / pageSize + 1,
                CurrentPage = page
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.All()
                .Where(s => s.Id == id)
                .Select(SnippetViewModel.Create)
                .FirstOrDefault();

            if (snippet == null)
            {
                return HttpNotFound();
            }

            return View(snippet);
        }

        [Authorize]
        public ActionResult MySnippets()
        {
            var loggedUserId = this.User.Identity.GetUserId();

            var mySnippets = this.Data.Snippets.All()
                .Where(s => s.AuthorId == loggedUserId)
                .Select(ShortSnippetViewModel.Create);

            var model = new MySnippetsPageViewModel()
            {
                Snippets = mySnippets
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            var allLanguages = this.Data.ProgrammingLanguages.All();
            var languages = new List<SelectListItem>();

            foreach (var language in allLanguages)
            {
                languages.Add(new SelectListItem { Text = language.Name, Value = language.Name });
            }

            var model = new NewSnippetPageViewModel()
            {
                Languages = new SelectList(languages, "text", "value", 1)
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NewSnippetPageViewModel model)
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == loggedUserId);

            if (model == null)
            {
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var language = this.Data.ProgrammingLanguages.All().Where(l => l.Name == model.Snippet.Language).FirstOrDefault();
            if (language == null)
            {
                return View(model);
            }

            var labels = model.Snippet.Labels.Split(';');

            var newSnippet = new Snippet()
            {
                Title = model.Snippet.Title,
                Description = model.Snippet.Description,
                Code = model.Snippet.Code,
                Language = language,
                Labels = new HashSet<Label>(),
                AuthorId = loggedUserId,
                CreatedOn = DateTime.Now
            };

            foreach (var labelName in labels)
            {
                string name = labelName.Trim();

                var label = this.Data.Labels.All().Where(l => l.Text == name).FirstOrDefault();

                if (label == null)
                {
                    label = new Label()
                    {
                        Text = name
                    };

                    this.Data.Labels.Add(label);
                    this.Data.SaveChanges();
                }

                newSnippet.Labels.Add(label);
            }

            this.Data.Snippets.Add(newSnippet);
            this.Data.SaveChanges();

            return RedirectToAction("Details", "Snippets", new { Id = newSnippet.Id } );
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var snippet = this.Data.Snippets.All()
                .Where(s => s.Id == id)
                .FirstOrDefault();

            if (snippet == null)
            {
                return HttpNotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();

            if (snippet.AuthorId != loggedUserId)
            {
                return RedirectToAction("Index", "Home");
            }

            var allLanguages = this.Data.ProgrammingLanguages.All();
            var languages = new List<SelectListItem>();

            foreach (var language in allLanguages)
            {
                languages.Add(new SelectListItem { Text = language.Name, Value = language.Name });
            }

            var model = new NewSnippetPageViewModel()
            {
                Snippet = new AddSnippetViewModel()
                {
                    Id = snippet.Id,
                    Title = snippet.Title,
                    Description = snippet.Description,
                    Code = snippet.Code,
                    Labels = string.Join("; ", snippet.Labels.Select(l => l.Text)),
                    Language = snippet.Language.Name
                },
                Languages = new SelectList(languages, "text", "value", 1)
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewSnippetPageViewModel model)
        {
            var snippet = this.Data.Snippets.All()
                .Where(s => s.Id == id)
                .FirstOrDefault();

            if (snippet == null)
            {
                return HttpNotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == loggedUserId);

            if (snippet.AuthorId != loggedUserId)
            {
                return RedirectToAction("Index", "Home");
            }

            if (model == null)
            {
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var language = this.Data.ProgrammingLanguages.All().Where(l => l.Name == model.Snippet.Language).FirstOrDefault();
            if (language == null)
            {
                return View(model);
            }

            var labels = model.Snippet.Labels.Split(';');

            snippet.Title = model.Snippet.Title;
            snippet.Description = model.Snippet.Description;
            snippet.Code = model.Snippet.Code;
            snippet.Language = language;
            snippet.Labels = new HashSet<Label>();

            foreach (var labelName in labels)
            {
                string name = labelName.Trim();

                var label = this.Data.Labels.All().Where(l => l.Text == name).FirstOrDefault();

                if (label == null)
                {
                    label = new Label()
                    {
                        Text = name
                    };

                    this.Data.Labels.Add(label);
                    this.Data.SaveChanges();
                }

                snippet.Labels.Add(label);
            }
            
            this.Data.SaveChanges();

            return RedirectToAction("Details", "Snippets", new { Id = id });
        }

        public ActionResult Search(string search)
        {
            var snippets = new HashSet<Snippet>();

            if (search != string.Empty)
            {
                var snippetsByTitle = this.Data.Snippets.All()
                .Where(s => s.Title.Contains(search));

                IEnumerable<Snippet> snippetsByLabels = this.Data.Labels.All()
                    .Where(l => l.Text.Contains(search))
                    .SelectMany(l => l.Snippets);
                
                foreach (var snippet in snippetsByTitle)
                {
                    snippets.Add(snippet);
                }

                foreach (var snippet in snippetsByLabels)
                {
                    snippets.Add(snippet);
                }
            }

            var model = new SearchPageViewModel()
            {
                Snippets = snippets.AsQueryable().Select(SnippetViewModel.Create)
            };

            return View(model);
        }
    }
}