using System.Collections.Generic;
using System.Web.Mvc;

namespace Snippy.Web.Models
{
    public class NewSnippetPageViewModel
    {
        public AddSnippetViewModel Snippet { get; set; }

        public SelectList Languages { get; set; }
    }
}