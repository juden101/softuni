namespace Products.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Data;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Newtonsoft.Json;
    using System.IO;

    class ConsoleClient
    {
        static void Main()
        {
            var context = new ProducsContext();

            // ExtractProductsInRange(context);

            // ExtractUsersWithSoldItems(context);

            // ExtractAllCategories(context);

            // ExtractUsersAndProducts(context);
        }

        private static void ExtractUsersAndProducts(ProducsContext context)
        {
            // Get all users who have at least 1 sold product.
            // Order them by the number of sold products (from highest to lowest),
            // then by last name (ascending).
            // Select only their first and last name, age
            // and for each product - name and price.

            var usersAndProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lasName = u.LastName,
                    age = u.Age,
                    products = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price
                    })
                    .ToList()
                })
                .ToList();

            var xmlUsers = new XElement("users");
            xmlUsers.Add(new XAttribute("count", usersAndProducts.Count));

            foreach (var user in usersAndProducts)
            {
                string firstName = user.firstName;
                string lastName = user.lasName;
                int? age = user.age;

                var xmlUser = new XElement("user");

                if (firstName != null)
                {
                    xmlUser.Add(new XAttribute("first-name", firstName));
                }

                if (lastName != null)
                {
                    xmlUser.Add(new XAttribute("last-name", lastName));
                }

                if (age != null)
                {
                    xmlUser.Add(new XAttribute("age", age));
                }

                var xmlSoldProducts = new XElement("sold-poducts");
                xmlSoldProducts.Add(new XAttribute("count", user.products.Count));

                foreach (var product in user.products)
                {
                    var xmlSoldProduct = new XElement("poduct");
                    xmlSoldProduct.Add(new XAttribute("name", product.name));
                    xmlSoldProduct.Add(new XAttribute("price", product.price));

                    xmlSoldProducts.Add(xmlSoldProduct);
                }

                xmlUser.Add(xmlSoldProducts);
                xmlUsers.Add(xmlUser);
            }

            File.WriteAllText(@"../../users-and-products.xml", xmlUsers.ToString());
        }

        private static void ExtractAllCategories(ProducsContext context)
        {
            // Get all categories.
            // Order them by the number of products in that category
            // (a product can be in many categories).
            // For each category select its name, the number of products,
            // the average price of those products and the total revenue
            // (total price sum) of those products
            // (regardless if they have a buyer or not).

            var allCategories = context.Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                })
                .ToList();

            var serializedAllCategories = JsonConvert.SerializeObject(allCategories);
            File.WriteAllText(@"../../categories-by-products.json", serializedAllCategories);
        }

        private static void ExtractUsersWithSoldItems(ProducsContext context)
        {
            // Get all users who have at least 1 sold item with a buyer.
            // Order them by last name, then by first name.
            // Select the person's first and last name.
            // For each of the sold products (products with buyers), select the product's name,
            // price and the buyer's first and last name.

            var usersWithSoldItems = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer.FirstName != null && p.Buyer.LastName != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            var serializedUsersWithSoldItems = JsonConvert.SerializeObject(usersWithSoldItems);
            File.WriteAllText(@"../../users-sold-products.json", serializedUsersWithSoldItems);
        }

        private static void ExtractProductsInRange(ProducsContext context)
        {
            // Get all products in a specified price range (e.g. 500 to 1000)
            // which have no buyer. Order them by price (from lowest to highest).
            // Select only the product name, price and the full name of the seller.
            // Export the result to JSON.

            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000 && p.Buyer == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            var serializedProductsInRange = JsonConvert.SerializeObject(productsInRange);
            File.WriteAllText(@"../../products-in-range.json", serializedProductsInRange);
        }
    }
}