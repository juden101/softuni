namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserViewModel
    {
        public string UserName { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    UserName = u.UserName,
                };
            }
        }
    }
}