using System.Collections.Generic;

namespace Snippy.Web.Models
{
    public class SearchPageViewModel
    {
        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}