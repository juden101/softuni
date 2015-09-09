using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    public class ShoppingCenterMain
    {
        public static void Main()
        {
            ShoppingCenter shoppingCenter = new ShoppingCenter();
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string commandLine = Console.ReadLine();

                Console.WriteLine(shoppingCenter.ProcessCommand(commandLine));
            }
        }
    }

    public class ShoppingCenter
    {
        private Dictionary<string, MultiDictionary<string, Product>> productsByName = new Dictionary<string, MultiDictionary<string, Product>>();
        private Dictionary<string, MultiDictionary<string, Product>> productsByProducer = new Dictionary<string, MultiDictionary<string, Product>>();
        private OrderedMultiDictionary<decimal, Product> productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);

        public string ProcessCommand(string commandLine)
        {
            int indexOfSplitChar = commandLine.IndexOf(' ');
            string command = commandLine.Substring(0, indexOfSplitChar).Trim();
            string[] parameters = commandLine.Substring(indexOfSplitChar + 1).Trim().Split(';');

            switch (command)
            {
                case "AddProduct":
                    Product product = new Product()
                    {
                        Name = parameters[0],
                        Price = decimal.Parse(parameters[1]),
                        Producer = parameters[2]
                    };

                    // add by name
                    if (!this.productsByName.ContainsKey(product.Name))
                    {
                        this.productsByName.Add(product.Name, new MultiDictionary<string, Product>(true));
                    }

                    this.productsByName[product.Name].Add(product.Producer, product);

                    // add by producer
                    if (!this.productsByProducer.ContainsKey(product.Producer))
                    {
                        this.productsByProducer.Add(product.Producer, new MultiDictionary<string, Product>(true));
                    }

                    this.productsByProducer[product.Producer].Add(product.Name, product);

                    // add by price
                    this.productsByPrice.Add(product.Price, product);

                    return "Product added";
                case "DeleteProducts":
                    if (parameters.Count() == 1)
                    {
                        // delete by producer
                        string producer = parameters[0];

                        if (this.productsByProducer.ContainsKey(producer))
                        {
                            var products = this.productsByProducer[producer].Values;
                            int deletedProductsCount = products.Count;

                            foreach (var currentProduct in products)
                            {
                                this.productsByName[currentProduct.Name].Remove(currentProduct.Producer);
                                this.productsByPrice[currentProduct.Price].Remove(currentProduct);
                            }

                            this.productsByProducer.Remove(producer);

                            if (deletedProductsCount > 0)
                            {
                                return string.Format("{0} products deleted", deletedProductsCount);
                            }
                        }

                        return "No products found";
                    }
                    else if (parameters.Count() == 2)
                    {
                        // delete by name and producer
                        string name = parameters[0];
                        string producer = parameters[1];

                        if (this.productsByProducer.ContainsKey(producer))
                        {
                            if (this.productsByProducer[producer].ContainsKey(name))
                            {
                                var products = this.productsByProducer[producer][name];
                                int deletedProductsCount = products.Count;

                                foreach (var currentProduct in products)
                                {
                                    this.productsByPrice[currentProduct.Price].Remove(currentProduct);
                                }

                                this.productsByProducer[producer].Remove(name);
                                this.productsByName[name].Remove(producer);

                                if (deletedProductsCount > 0)
                                {
                                    return string.Format("{0} products deleted", deletedProductsCount);
                                }
                            }
                        }

                        return "No products found";
                    }

                    return "No products found";
                case "FindProductsByName":
                    string productName = parameters[0];

                    if(this.productsByName.ContainsKey(productName))
                    {
                        var products = this.productsByName[productName].Values.OrderBy(p => p);

                        if (products.Any())
                        {
                            return string.Join(Environment.NewLine, products);
                        }
                    }

                    return "No products found";
                case "FindProductsByProducer":
                    string producerName = parameters[0];

                    if (this.productsByProducer.ContainsKey(producerName))
                    {
                        var products = this.productsByProducer[producerName].Values.OrderBy(p => p);

                        if (products.Any())
                        {
                            return string.Join(Environment.NewLine, products);
                        }
                    }

                    return "No products found";
                case "FindProductsByPriceRange":
                    decimal startPrice = decimal.Parse(parameters[0]);
                    decimal endPrice = decimal.Parse(parameters[1]);
                    var productsInRange = this.productsByPrice.Range(startPrice, true, endPrice, true).Values.OrderBy(p => p);

                    if (productsInRange.Any())
                    {
                        return string.Join(Environment.NewLine, productsInRange);
                    }

                    return "No products found";
                default:
                    return "Invalid command";
            }
        }

        public class Product : IComparable<Product>
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Producer { get; set; }

            public override string ToString()
            {
                return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
            }

            public int CompareTo(Product other)
            {
                if (this == other)
                {
                    return 0;
                }

                var result = this.Name.CompareTo(other.Name);
                
                if (result == 0)
                {
                    result = this.Producer.CompareTo(other.Producer);
                }

                if (result == 0)
                {
                    result = this.Price.CompareTo(other.Price);
                }

                return result;
            }
        }
    }
}