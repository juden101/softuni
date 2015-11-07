using Snippy.Models;
using System;
using System.Linq.Expressions;

namespace Snippy.Web.Models
{
    public class ShortCommentViewModel
    {
        public int Id { get; set; }
        
        public string Author { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public string Content { get; set; }
        
        public int SnippetId { get; set; }

        public string SnippetTitle { get; set; }

        public static Expression<Func<Comment, ShortCommentViewModel>> Create
        {
            get
            {
                return s => new ShortCommentViewModel()
                {
                    Id = s.Id,
                    Author = s.Author.UserName,
                    CreatedOn = s.CreatedOn,
                    Content = s.Content,
                    SnippetId = s.Snippet.Id,
                    SnippetTitle = s.Snippet.Title
                };
            }
        }
    }
}