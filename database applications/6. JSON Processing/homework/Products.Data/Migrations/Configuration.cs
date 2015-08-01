namespace Products.Data.Migrations
{
    using Newtonsoft.Json;
    using Products.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    internal sealed class Configuration : DbMigrationsConfiguration<Products.Data.ProducsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Products.Data.ProducsContext";
        }

        protected override void Seed(Products.Data.ProducsContext context)
        {
            return;

            // import users

            var xmlDoc = XDocument.Load("../../../users.xml");
            var userNodes = xmlDoc.XPathSelectElements("users/user");

            foreach (var userNode in userNodes)
            {
                string firstName = null;
                string lastName = null;
                int? age = null;

                if (userNode.Attribute("first-name") != null)
                {
                    firstName = userNode.Attribute("first-name").Value;
                }

                if (userNode.Attribute("last-name") != null)
                {
                    lastName = userNode.Attribute("last-name").Value;
                }

                if (userNode.Attribute("age") != null)
                {
                    age = int.Parse(userNode.Attribute("age").Value);
                }

                User user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                context.Users.Add(user);
            }

            context.SaveChanges();

            // import categories

            string jsonCategoriesInput = File.ReadAllText("../../../categories.json");
            var categories = JsonConvert.DeserializeObject<Category[]>(jsonCategoriesInput);

            foreach (var category in categories)
            {
                Category newCategory = new Category
                {
                    Name = category.Name
                };

                context.Categories.Add(newCategory);
            }

            context.SaveChanges();

            // import products

            string jsonInput = System.IO.File.ReadAllText("../../../products.json");
            var products = JsonConvert.DeserializeObject<Product[]>(jsonInput);

            Random random = new Random();
            List<User> users = context.Users.ToList();
            List<Category> allCategories = context.Categories.ToList();

            foreach (var product in products)
            {
                User buyer = null;

                if (random.Next(100) < 60)
                {
                    int currentBuyerId = random.Next(0, users.Count());
                    buyer = users[currentBuyerId];
                }

                int currentSellerId = random.Next(0, users.Count());
                User seller = users[currentSellerId];

                int currentCategoryId = random.Next(0, allCategories.Count());
                Category currentCategory = allCategories[currentCategoryId];

                Product newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Buyer = buyer,
                    Seller = seller,
                    Categories = new List<Category>()
                    {
                        currentCategory
                    }
                };

                context.Products.Add(newProduct);
            }

            context.SaveChanges();
        }
    }
}
