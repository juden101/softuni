using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.Web.Models.ViewModels
{
    public class EditProfileViewModel
    {
        public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public string Biography { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}