using System.Collections.Generic;

namespace Snippy.Web.Models
{
    public class MySnippetsPageViewModel
    {
        public IEnumerable<ShortSnippetViewModel> Snippets { get; set; }
    }
}