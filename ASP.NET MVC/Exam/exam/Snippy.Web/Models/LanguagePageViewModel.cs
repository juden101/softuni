using System.Collections.Generic;

namespace Snippy.Web.Models
{
    public class LanguagePageViewModel
    {
        public ShortLanguageViewModel Language { get; set; }

        public IEnumerable<ShortSnippetViewModel> Snippets { get; set; }
    }
}