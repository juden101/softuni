using Snippy.Models;
using System;
using System.Linq.Expressions;

namespace Snippy.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        
        public string Author { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public string Content { get; set; }
        
        public int SnippetId { get; set; }

        public string SnippetTitle { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> Create
        {
            get
            {
                return s => new CommentViewModel()
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