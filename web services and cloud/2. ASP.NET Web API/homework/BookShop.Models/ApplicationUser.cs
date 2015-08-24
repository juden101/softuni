namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser, IUser
    {
        private ICollection<Purchaise> purchaises;

        public ApplicationUser()
        {
            this.purchaises = new HashSet<Purchaise>();
        }

        public virtual ICollection<Purchaise> Purchaises
        {
            get { return this.purchaises; }
            set { this.purchaises = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}