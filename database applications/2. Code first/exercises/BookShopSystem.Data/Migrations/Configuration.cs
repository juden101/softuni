namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    using Models;
    using System.Globalization;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            List<Category> categories = this.LoadCategories("../../../Data/categories.txt");
            List<Author> authors = this.LoadAuthors("../../../Data/authors.txt");
            List<Book> books = this.LoadBooks("../../../Data/books.txt", categories, authors);

            foreach (Book book in books)
            {
                context.Books.AddOrUpdate(book);
            }
        }

        private List<Category> LoadCategories(string filePath)
        {
            List<Category> categories = new List<Category>();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    Category category = new Category()
                    {
                        Name = line.Trim()
                    };

                    categories.Add(category);

                    line = reader.ReadLine();
                }
            }

            return categories;
        }

        private List<Author> LoadAuthors(string filePath)
        {
            List<Author> authors = new List<Author>();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' });
                    var firstName = data[0];
                    var lastName = data[1];

                    Author author = new Author()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };

                    authors.Add(author);

                    line = reader.ReadLine();
                }
            }

            return authors;
        }

        private List<Book> LoadBooks(string filePath, List<Category> categories, List<Author> authors)
        {
            Random random = new Random();
            List<Book> books = new List<Book>();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, authors.Count());
                    var author = authors[authorIndex];
                    var type = (BookType)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (BookAgeRestriction)int.Parse(data[4]);
                    var title = data[5];
                    var bookCategories = new List<Category>();
                    bookCategories.Add(categories[random.Next(0, categories.Count)]);
                    bookCategories.Add(categories[random.Next(0, categories.Count)]);

                    books.Add(new Book()
                    {
                        Author = author,
                        Type = type,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title,
                        Categories = bookCategories
                    });

                    line = reader.ReadLine();
                }
            }

            return books;
        }
    }
}