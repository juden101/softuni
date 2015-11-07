using System.Collections.Generic;

namespace Snippy.Web.Models
{
    public class SnippetPageViewModel
    {
        public IEnumerable<SnippetViewModel> Snippets { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }
}