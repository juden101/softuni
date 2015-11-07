using Snippy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snippy.Web.Models
{
    public class ShortLanguageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<ShortSnippetViewModel> Snippets { get; set; }

        public static Expression<Func<ProgrammingLanguage, ShortLanguageViewModel>> Create
        {
            get
            {
                return l => new ShortLanguageViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Snippets = l.Snippets.AsQueryable().Select(ShortSnippetViewModel.Create)
                };
            }
        }
    }
}