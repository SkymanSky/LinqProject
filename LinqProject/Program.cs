using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Bilgisayar"},
                new Category{CategoryId=2, CategoryName="Telefon"},

            };

            List<Product> products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Acer Laptop",
                    QuantityPerUnit = "32 Gb Ram",
                    UnitPrice = 10000,
                    UnitsInStock = 5
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Asus Laptop",
                    QuantityPerUnit = "16 Gb Ram",
                    UnitPrice = 8000,
                    UnitsInStock = 3
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ProductName = "Hp Laptop",
                    QuantityPerUnit = "8 Gb Ram",
                    UnitPrice = 10000,
                    UnitsInStock = 3
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ProductName = "Samsung Telefon",
                    QuantityPerUnit = "4 Gb Ram",
                    UnitPrice = 5000,
                    UnitsInStock = 15
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductName = "Apple Telefon",
                    QuantityPerUnit = "4 Gb Ram",
                    UnitPrice = 8000,
                    UnitsInStock = 0
                },

            };

            var result = from p in products
                join c in categories on p.CategoryId equals c.CategoryId
                where p.UnitPrice > 5000
            orderby p.UnitPrice descending 
                select new ProductDto
                {
                    ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice
                };

            foreach (var productDto in result)
            {
                //Console.WriteLine(productDto.ProductName+" - "+productDto.CategoryName);

                Console.WriteLine("{0}----{1}",productDto.ProductName,productDto.CategoryName);

            }

            //AnyTest(products);

            //FindTest(products);

            //FindAllTest(products);

            //WhereTest(products);

            //ClassLinqTest(products);

            //Console.WriteLine("Algoritma--------------------");

            //foreach (var product in products)
            //{
            //    if (product.UnitPrice > 5000 && product.UnitsInStock>3)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }

            //}



            //Console.WriteLine("Linq--------------------");
            //var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);
            //foreach (var product in result)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            // Console.WriteLine("GetProductsLinq--------------------");
            // GetProductsLinq(products);
            // Console.WriteLine(product.ProductName);


            //Console.WriteLine(products.Count);

            Console.ReadLine();
        }

        private static void ClassLinqTest(List<Product> products)
        {
            var result = from p in products
                where p.UnitPrice > 6000 && p.ProductName.Contains("Lap")
                orderby p.ProductName descending
                select p;

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void WhereTest(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice)
                .ThenBy(p => p.ProductName);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.CategoryId == 1);
            foreach (var r in result)
            {
                Console.WriteLine(r.ProductName);
            }

            var result2 = products.FindAll(p => p.ProductName.Contains("Tel"));
            foreach (var r in result2)
            {
                Console.WriteLine(r.ProductName);
            }
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Lapop");
            Console.WriteLine(result);
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(product => product.UnitPrice > 5000 && product.UnitsInStock > 2).ToList();
            //Console.WriteLine(products.Count());

        }

    }

    class ProductDto
    {
        public object ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }
    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
