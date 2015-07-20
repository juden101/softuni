namespace BookShopSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Models;
    using Data;

    public class BookShopSystemConsoleClient
    {
        public static void Main()
        {
            var context = new BookShopContext();

            // 1. Get all books after the year 2000. Select only their titles.
            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year > 2000)
                .Select(b => b.Title);

            foreach (var bookTitle in bookTitles)
            {
                Console.WriteLine(bookTitle);
            }

            // 2. Get all authors with at least one book with release date before 1990.
            // Select their first name and last name.

            var authors = context.Author
                .Where(a => a.Books
                    .Any(b => b.ReleaseDate.Value.Year < 1990))
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName
                });

            foreach (var author in authors)
            {
                Console.WriteLine("{0} {1}", author.FirstName, author.LastName);
            }

            // 3. Get all authors, ordered by the number of their books (descending).
            // Select their first name, last name and book count.

            var authorsByBooks = context.Author
                .OrderByDescending(a => a.Books.Count)
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BooksCount = a.Books.Count
                });

            foreach (var author in authorsByBooks)
            {
                Console.WriteLine("{0} {1}, {2} books", author.FirstName, author.LastName, author.BooksCount);
            }

            // 4. Get all books from author George Powell, ordered by their release date (descending),
            // then by book title (ascending). Select the book's title, release date and copies.

            var specificAuthorBooks = context.Books
                .Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.Copies
                });

            foreach (var book in specificAuthorBooks)
            {
                Console.WriteLine("{0}, Released: {1}, {2} copies", book.Title, book.ReleaseDate, book.Copies);
            }

            // 5. Get the most recent books by categories. The categories should be ordered by total book count.
            // Only take the top 3 most recent books from each category - ordered by date (descending),
            // then by title (ascending). Select the category name, total book count and for each book
            // its title and release date.

            var categoriesWithBooks = context.Category
                .OrderByDescending(c => c.Books.Count)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksCount = c.Books.Count,
                    Books = c.Books
                        .Take(3)
                        .OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title)
                        .Select(b => new
                        {
                            b.Title,
                            b.ReleaseDate
                        })
                        .ToList()
                });

            foreach (var category in categoriesWithBooks)
            {
                Console.WriteLine("--{0}: {1}", category.CategoryName, category.BooksCount);

                foreach (var book in category.Books)
                {
                    Console.WriteLine("{0} ({1})", book.Title, book.ReleaseDate.Value.Year);
                }
            }

            var relatedBooks = context.Books
                .Take(3)
                .ToList();

            relatedBooks[0].RelatedBooks.Add(relatedBooks[1]);
            relatedBooks[1].RelatedBooks.Add(relatedBooks[0]);
            relatedBooks[0].RelatedBooks.Add(relatedBooks[2]);
            relatedBooks[2].RelatedBooks.Add(relatedBooks[0]);

            context.SaveChanges();

            // Query the first three books
            // and get their names and their related book names

            var booksFromQuery = context.Books
                .Take(3)
                .Select(b => new
                {
                    Title = b.Title,
                    RelatedBooks = b.RelatedBooks
                        .Select(rb => rb.Title)
                });

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);

                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook);
                }
            }
        }
    }
}