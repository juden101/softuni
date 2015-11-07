using Snippy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Snippy.Web.Models
{
    public class SnippetViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Code { get; set; }
        
        public ProgrammingLanguage Language { get; set; }
        
        public ApplicationUser Author { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Snippet, SnippetViewModel>> Create
        {
            get
            {
                return s => new SnippetViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Code = s.Code,
                    Language = s.Language,
                    Author = s.Author,
                    CreatedOn = s.CreatedOn,
                    Labels = s.Labels.AsQueryable().Select(LabelViewModel.Create),
                    Comments = s.Comments.AsQueryable().Select(CommentViewModel.Create)
                };
            }
        }
    }
}