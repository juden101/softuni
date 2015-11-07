namespace Snippy.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Snippet> ownSnippets;

        public ApplicationUser()
        {
            this.ownSnippets = new HashSet<Snippet>();
        }

        public virtual ICollection<Snippet> OwnSnippets
        {
            get { return this.ownSnippets; }
            set { this.ownSnippets = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}