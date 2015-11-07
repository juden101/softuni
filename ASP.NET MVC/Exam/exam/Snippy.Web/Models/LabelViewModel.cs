using Snippy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snippy.Web.Models
{
    public class LabelViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SnippetsCount { get; set; }

        public static Expression<Func<Label, LabelViewModel>> Create
        {
            get
            {
                return l => new LabelViewModel()
                {
                    Id = l.Id,
                    Text = l.Text,
                    SnippetsCount = l.Snippets.Count
                };
            }
        }
    }
}