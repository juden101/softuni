using Snippy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snippy.Web.Models
{
    public class ShortLabelViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual IEnumerable<ShortSnippetViewModel> Snippets { get; set; }

        public static Expression<Func<Label, ShortLabelViewModel>> Create
        {
            get
            {
                return l => new ShortLabelViewModel()
                {
                    Id = l.Id,
                    Text = l.Text,
                    Snippets = l.Snippets.AsQueryable().Select(ShortSnippetViewModel.Create)
                };
            }
        }
    }
}