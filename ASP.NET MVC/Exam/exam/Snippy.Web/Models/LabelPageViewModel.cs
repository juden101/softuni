using System.Collections.Generic;

namespace Snippy.Web.Models
{
    public class LabelPageViewModel
    {
        public ShortLabelViewModel Label { get; set; }

        public IEnumerable<ShortSnippetViewModel> Snippets { get; set; }
    }
}