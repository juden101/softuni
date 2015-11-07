using Snippy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Snippy.Web.Models
{
    public class ShortSnippetViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }

        public static Expression<Func<Snippet, ShortSnippetViewModel>> Create
        {
            get
            {
                return s => new ShortSnippetViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Labels = s.Labels.AsQueryable().Select(LabelViewModel.Create)
                };
            }
        }
    }
}