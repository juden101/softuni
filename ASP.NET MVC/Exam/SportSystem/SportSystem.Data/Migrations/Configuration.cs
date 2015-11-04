namespace SportSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SportSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SportSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                this.CreateUser(context, "alex@usa.net", "12qw!@QW");
                this.CreateUser(context, "tanya@gmail.com", "P@ssW0RD!123");
                context.SaveChanges();
            }

            if (!context.Teams.Any())
            {
                this.CreateTeam(context, "Manchester United F.C.", "http://www.manutd.com", DateTime.Parse("1-Jun-1878"), "The Red Devils");
                this.CreateTeam(context, "Real Madrid", "http://www.realmadrid.com", DateTime.Parse("6-Mar-1902"), "The Whites");
                this.CreateTeam(context, "FC Barcelona", "http://www.fcbarcelona.com", DateTime.Parse("12-Nov-1899"), "Barca");
                this.CreateTeam(context, "Bayern Munich", "http://www.fcbayern.de", DateTime.Parse("13-Feb-1900"), "The Bavarians");
                this.CreateTeam(context, "Manchester City", "http://www.mcfc.com", DateTime.Parse("1-May-1880"), "The Citizens");
                this.CreateTeam(context, "Chelsea", "https://www.chelseafc.com", DateTime.Parse("10-Mar-1905"), "The Pensioners");
                this.CreateTeam(context, "Arsenal", "http://www.arsenal.com", DateTime.Parse("1-Sep-1886"), "The Gunners");
                context.SaveChanges();
            }

            if (!context.Matches.Any())
            {
                this.CreateMatch(context, "Real Madrid", "Manchester United F.C.", DateTime.Parse("2015-Jun-13"));
                this.CreateMatch(context, "Bayern Munich", "Manchester United F.C.", DateTime.Parse("2015-Jun-14"));
                this.CreateMatch(context, "FC Barcelona", "Manchester City", DateTime.Parse("2015-Jun-15"));
                this.CreateMatch(context, "Chelsea", "FC Barcelona", DateTime.Parse("2015-Jun-16"));
                this.CreateMatch(context, "Real Madrid", "Manchester City",	DateTime.Parse("2015-Jun-17"));
                this.CreateMatch(context, "Manchester United F.C.",	"Chelsea", DateTime.Parse("2015-Jun-18"));
                this.CreateMatch(context, "Arsenal", "Bayern Munich", DateTime.Parse("2015-Jun-12"));
                this.CreateMatch(context, "Chelsea", "Real Madrid",	DateTime.Parse("2015-Jun-11"));
                this.CreateMatch(context, "Chelsea", "Manchester City",	DateTime.Parse("2015-Jun-10"));
                this.CreateMatch(context, "Chelsea", "Arsenal",	DateTime.Parse("2015-Jun-19"));
                this.CreateMatch(context, "Arsenal", "FC Barcelona", DateTime.Parse("2015 - Jun - 20"));
                context.SaveChanges();
            }

            if (!context.Players.Any())
            {
                this.CreatePlayer(context, "Alexis Sanchez", DateTime.Parse("1982-01-03"),	1.65,	"FC Barcelona");
                this.CreatePlayer(context, "Arjen Robben", DateTime.Parse("1982-01-03"), 1.65,	"Real Madrid");
                this.CreatePlayer(context, "Franck Ribery",	DateTime.Parse("1982-01-03"), 1.65,	"Manchester United F.C.");
                this.CreatePlayer(context, "Wayne Rooney", DateTime.Parse("1982-01-03"), 1.65,	"Manchester United F.C.");
                this.CreatePlayer(context, "Lionel Messi", DateTime.Parse("1982-01-13"), 1.65);
                this.CreatePlayer(context, "Theo Walcott", DateTime.Parse("1983-02-17"), 1.75);
                this.CreatePlayer(context, "Cristiano Ronaldo",	DateTime.Parse("1984-03-16"), 1.85);
                this.CreatePlayer(context, "Aaron Lennon", DateTime.Parse("1985-04-15"), 1.95);
                this.CreatePlayer(context, "Gareth Bale", DateTime.Parse("1986-05-14"),	1.90);
                this.CreatePlayer(context, "Antonio Valencia", DateTime.Parse("1987-05-23"), 1.82);
                this.CreatePlayer(context, "Robin van Persie", DateTime.Parse("1988-06-13"), 1.84);
                this.CreatePlayer(context, "Ronaldinho", DateTime.Parse("1989-07-30"), 1.87);
                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                this.CreateComment(context, "Bayern Munich", "Manchester United F.C.", "The best match this summer!", "alex@usa.net");
                this.CreateComment(context, "Bayern Munich", "Manchester United F.C.", "The good football this evening.", "tanya@gmail.com");
                this.CreateComment(context, "FC Barcelona", "Manchester City", "Barca!", "tanya@gmail.com");
                this.CreateComment(context, "Real Madrid", "Manchester City", "Real forever!", "alex@usa.net");
                this.CreateComment(context, "Real Madrid", "Manchester City", "Real, real, real", "alex@usa.net");
                this.CreateComment(context, "Real Madrid", "Manchester City", "Real again :)", "alex@usa.net");
                this.CreateComment(context, "Chelsea", "Real Madrid", "Chelsea champion!", "tanya@gmail.com");
                context.SaveChanges();
            }

            if (!context.Bets.Any())
            {
                this.CreateBet(context, "Chelsea", "FC Barcelona", 30.00m, 0.00m, "alex@usa.net");
                this.CreateBet(context, "Chelsea", "FC Barcelona", 0.00m, 50.00m, "alex@usa.net");
                this.CreateBet(context, "Chelsea", "FC Barcelona", 0.00m, 120.00m, "alex@usa.net");
                this.CreateBet(context, "FC Barcelona", "Manchester City", 120.00m, 0.00m, "alex@usa.net");
                this.CreateBet(context, "Bayern Munich ", "Manchester United F.C.", 500.00m, 0.00m, "alex@usa.net");
                this.CreateBet(context, "Bayern Munich ", "Manchester United F.C.", 50.00m, 0.00m, "tanya@gmail.com");
                this.CreateBet(context, "Bayern Munich ", "Manchester United F.C.", 0.00m, 20.00m, "tanya@gmail.com");
                this.CreateBet(context, "Chelsea", "FC Barcelona", 0.00m, 220.00m, "tanya@gmail.com");
                context.SaveChanges();
            }

            if (!context.Votes.Any())
            {
                this.CreateVote(context, "Bayern Munich", "tanya@gmail.com");
                this.CreateVote(context, "Real Madrid", "tanya@gmail.com");
                this.CreateVote(context, "Bayern Munich", "alex@usa.net");
                context.SaveChanges();
            }

            base.Seed(context);
        }

        private void CreateVote(ApplicationDbContext context, string team, string user)
        {
            context.Votes.Add(
                new Vote()
                {
                    Team = context.Teams.Where(t => t.Name == team).FirstOrDefault(),
                    VotingUser = context.Users.Where(u => u.Email == user).FirstOrDefault()
                }
            );
        }

        private void CreateBet(ApplicationDbContext context, string homeTeam, string awayTeam, decimal homeBet, decimal awayBet, string user)
        {
            Match match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == homeTeam && m.AwayTeam.Name == awayTeam);

            context.Bets.Add(
                new Bet()
                {
                    Match = match,
                    BettingUser = context.Users.Where(u => u.Email == user).FirstOrDefault(),
                    HomeBet = homeBet,
                    AwayBet = awayBet
                }
            );
        }

        private void CreateComment(ApplicationDbContext context, string homeTeam, string awayTeam, string comment, string user)
        {
            Match match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == homeTeam && m.AwayTeam.Name == awayTeam);

            context.Comments.Add(
                new Comment()
                {
                    Match = match,
                    DateAndTime = DateTime.Now,
                    Author = context.Users.Where(u => u.Email == user).FirstOrDefault(),
                    Content = comment
                }
            );
        }

        private void CreatePlayer(ApplicationDbContext context, string name, DateTime birthDate, double height, string team = "")
        {
            context.Players.Add(new Player()
            {
                Name = name,
                DateOfBirth = birthDate,
                Height = height,
                Team = team != String.Empty ? context.Teams.Where(t => t.Name == team).FirstOrDefault() : null
            });
        }

        private void CreateMatch(ApplicationDbContext context, string homeTeam, string awayTeam, DateTime matchDate)
        {
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.Where(t => t.Name == homeTeam).First(),
                AwayTeam = context.Teams.Where(t => t.Name == awayTeam).First(),
                DateAndTime = matchDate
            });
        }

        private void CreateTeam(ApplicationDbContext context, string name, string website, DateTime dateFounded, string nickname)
        {
            context.Teams.Add(new Team()
            {
                Name = name,
                Website = website,
                DateFounded = dateFounded,
                NickName = nickname
            });
        }

        private void CreateUser(ApplicationDbContext context, string username, string password)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userToInsert = new ApplicationUser { UserName = username, Email = username };
            userManager.Create(userToInsert, password);
        }
    }
}
