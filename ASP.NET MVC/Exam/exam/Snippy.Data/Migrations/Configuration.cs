namespace Snippy.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
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
                this.CreateUser(context, "admin", "admin@snippy.softuni.com", "adminPass123", "Admin");
                this.CreateUser(context, "someUser", "someUser@example.com", "someUserPass123");
                this.CreateUser(context, "newUser", "new_user@gmail.com", "userPass123");

                context.SaveChanges();
            }

            if (!context.Labels.Any())
            {
                this.CreateLabel(context, "bug");
                this.CreateLabel(context, "funny");
                this.CreateLabel(context, "jquery");
                this.CreateLabel(context, "mysql");
                this.CreateLabel(context, "useful");
                this.CreateLabel(context, "web");
                this.CreateLabel(context, "geometry");
                this.CreateLabel(context, "back-end");
                this.CreateLabel(context, "front-end");
                this.CreateLabel(context, "games");

                context.SaveChanges();
            }

            if (!context.ProgrammingLanguages.Any())
            {
                this.CreateLanguage(context, "C#");
                this.CreateLanguage(context, "JavaScript");
                this.CreateLanguage(context, "Python");
                this.CreateLanguage(context, "CSS");
                this.CreateLanguage(context, "SQL");
                this.CreateLanguage(context, "PHP");

                context.SaveChanges();
            }

            if (!context.Snippets.Any())
            {
                this.CreateSnippet(context,
                    "Ternary Operator Madness",
                    "This is how you DO NOT user ternary operators in C#!",
                    "bool X = Glob.UserIsAdmin ? true : false;",
                    "admin",
                    DateTime.ParseExact("26.10.2015 17:20:33", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "C#",
                    new string[] { "funny" });

                this.CreateSnippet(context,
                    "Points Around A Circle For GameObject Placement",
                    "Determine points around a circle which can be used to place elements around a central point",
                    @"private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)
                    {
                        float ptRatio = currentPoint / totalPoints;
                        float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;
                        float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;

                        Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);

                        return panelCenter;
                    }",
                    "admin",
                    DateTime.ParseExact("26.10.2015 20:15:30", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "C#",
                    new string[] { "geometry", "games" });

                this.CreateSnippet(context,
                    "forEach. How to break?",
                    "Array.prototype.forEach You can't break forEach. So use \"some\" or \"every\". Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true. Array.prototype.every every is almost identical to some except it's expecting false to break the loop.",
                    @"var ary = [""JavaScript"", ""Java"", ""CoffeeScript"", ""TypeScript""];

                    ary.some(function(value, index, _ary) {
                        console.log(index + "": "" + value);
                        return value === ""CoffeeScript"";
                    });
                    // output: 
                    // 0: JavaScript
                    // 1: Java
                    // 2: CoffeeScript

                    ary.every(function(value, index, _ary) {
                        console.log(index + "": "" + value);
                        return value.indexOf(""Script"") > -1;
                    });
                    // output:
                    // 0: JavaScript
                    // 1: Java",
                    "newUser",
                    DateTime.ParseExact("27.10.2015 10:53:20", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "JavaScript",
                    new string[] { "jquery", "useful", "web", "front-end" });

                this.CreateSnippet(context,
                    "Numbers only in an input field",
                    "Method allowing only numbers (positive / negative / with commas or decimal points) in a field",
                    @"$(""#input"").keypress(function(event){
	                    var charCode = (event.which) ? event.which : window.event.keyCode;
	                    if (charCode <= 13) { return true; } 
	                    else {
                            var keyChar = String.fromCharCode(charCode);
                            var regex = new RegExp(""[0-9,.-]"");
                            return regex.test(keyChar);
                        }
                    });",
                    "newUser",
                    DateTime.ParseExact("28.10.2015 09:00:56", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "JavaScript",
                    new string[] { "web", "front-end" });

                this.CreateSnippet(context,
                    "Create a link directly in an SQL query",
                    "That's how you create links - directly in the SQL!",
                    @"SELECT DISTINCT
                                    b.Id,
                                    concat('<button type=""button"" onclick=""DeleteContact(', cast(b.Id as char), ')"">Delete...</button>') as lnkDelete
                    FROM tblContact   b
                    WHERE ....",
                    "admin",
                    DateTime.ParseExact("30.10.2015 11:20:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "SQL",
                    new string[] { "bug", "funny", "mysql" });

                this.CreateSnippet(context,
                    "Reverse a String",
                    "Almost not worth having a function for...",
                    @"def reverseString(s):
	                """"Reverses a string given to it.""""
                    return s[::- 1]",
                    "admin",
                    DateTime.ParseExact("26.10.2015 09:35:13", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Python",
                    new string[] { "useful" });

                this.CreateSnippet(context,
                    "Pure CSS Text Gradients",
                    "This code describes how to create text gradients using only pure CSS",
                    @"/* CSS text gradients */
                    h2[data-text] {
	                    position: relative;
                    }
                    h2[data-text]::after {
	                    content: attr(data-text);
	                    z-index: 10;
	                    color: #e3e3e3;
	                    position: absolute;
	                    top: 0;
	                    left: 0;
	                    -webkit-mask-image: -webkit-gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));",
                    "someUser",
                    DateTime.ParseExact("22.10.2015 19:26:42", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "CSS",
                    new string[] { "web", "front-end" });

                this.CreateSnippet(context,
                    "Check for a Boolean value in JS",
                    "How to check a Boolean value - the wrong but funny way :D",
                    @"var b = true;

                    if (b.toString().length < 5) {
                        //...
                    }",
                    "admin",
                    DateTime.ParseExact("22.10.2015 05:30:04", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "JavaScript",
                    new string[] { "funny" });

                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                this.CreateComment(context,
                    "Now that's really funny! I like it!",
                    "admin",
                    DateTime.ParseExact("30.10.2015 11:50:38", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Ternary Operator Madness");

                this.CreateComment(context,
                    "Here, have my comment!",
                    "newUser",
                    DateTime.ParseExact("01.11.2015 15:52:42", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Ternary Operator Madness");

                this.CreateComment(context,
                    "I didn't manage to comment first :(",
                    "someUser",
                    DateTime.ParseExact("02.11.2015 05:30:20", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Ternary Operator Madness");

                this.CreateComment(context,
                    "That's why I love Python - everything is so simple!",
                    "newUser",
                    DateTime.ParseExact("27.10.2015 15:28:14", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Reverse a String");

                this.CreateComment(context,
                    "I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject",
                    "someUser",
                    DateTime.ParseExact("29.10.2015 15:08:42", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Points Around A Circle For GameObject Placement");

                this.CreateComment(context,
                    "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I'm ready.",
                    "admin",
                    DateTime.ParseExact("03.11.2015 12:56:20", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    "Numbers only in an input field");

                context.SaveChanges();
            }

            base.Seed(context);
        }

        private void CreateComment(ApplicationDbContext context, string content, string authorName, DateTime createdOn, string snippetTitle)
        {
            ApplicationUser author = context.Users.Where(u => u.UserName == authorName).FirstOrDefault();
            Snippet snippet = context.Snippets.Where(s => s.Title == snippetTitle).FirstOrDefault();

            context.Comments.Add(
                new Comment()
                {
                    Author = author,
                    Content = content,
                    CreatedOn = createdOn,
                    Snippet = snippet
                }
            );
        }

        private void CreateSnippet(ApplicationDbContext context, string title, string description, string code,
            string authorName, DateTime createdOn, string languageName, string[] labels)
        {
            ApplicationUser author = context.Users.Where(u => u.UserName == authorName).FirstOrDefault();
            ProgrammingLanguage language = context.ProgrammingLanguages.Where(p => p.Name == languageName).FirstOrDefault();

            var newSnippet = new Snippet()
            {
                Title = title,
                Description = description,
                Code = code,
                Language = language,
                Author = author,
                CreatedOn = createdOn
            };

            foreach (string labelText in labels)
            {
                var label = context.Labels.Where(l => l.Text == labelText).FirstOrDefault();
                newSnippet.Labels.Add(label);
            }

            context.Snippets.Add(newSnippet);
        }

        private void CreateLanguage(ApplicationDbContext context, string name)
        {
            context.ProgrammingLanguages.Add(
                new ProgrammingLanguage()
                {
                    Name = name
                }
            );
        }

        private void CreateLabel(ApplicationDbContext context, string text)
        {
            context.Labels.Add(
                new Label()
                {
                    Text = text
                }
            );
        }

        private void CreateUser(ApplicationDbContext context, string username, string email, string password, string roleName = "")
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userToInsert = new ApplicationUser { UserName = username, Email = email };
            userManager.Create(userToInsert, password);

            if (roleName != String.Empty)
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var role = new IdentityRole { Name = roleName };

                    roleManager.Create(role);
                    userManager.AddToRole(userToInsert.Id, roleName);
                }
            }
        }
    }
}
