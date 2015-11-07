using System.Collections.Generic;

namespace Snippy.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SnippetViewModel> LastSnippets { get; set; }

        public IEnumerable<ShortCommentViewModel> LastComments { get; set; }

        public IEnumerable<LabelViewModel> BestLabels { get; set; }
    }
}