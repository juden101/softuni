namespace SportSystem.Data
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SportSystem.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasRequired(match => match.HomeTeam)
                .WithMany(team => team.HomeMatches)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(match => match.AwayTeam)
                .WithMany(team => team.AwayMatches)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasOptional(player => player.Team)
                .WithMany(team => team.Players)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}