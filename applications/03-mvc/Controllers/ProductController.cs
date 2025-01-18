using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // Action to return a list of products
        public IActionResult Index()
        {
            // Simulating a product list (usually comes from a database)
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99M },
                new Product { Id = 2, Name = "Smartphone", Price = 799.99M }
            };

            return View(products);  // Passing the list of products to the view
        }

        // Action to return a specific product (you could extend this functionality)
        public IActionResult Details(int id)
        {
            var product = new Product { Id = id, Name = "Laptop", Price = 999.99M };

            return View(product);  // Passing the product details to the view
        }

        // Action to download the product list as a .txt file
        public IActionResult DownloadProductListAsTxt()
        {
            // Simulating a product list (usually comes from a database)
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99M },
                new Product { Id = 2, Name = "Smartphone", Price = 799.99M }
            };

            // Generate the plain text content
            string txtContent = GenerateProductListText(products);

            // Convert the string to a byte array
            byte[] byteArray = Encoding.UTF8.GetBytes(txtContent);

            // Return the byte array as a downloadable .txt file
            return File(byteArray, "text/plain", "ProductList.txt");
        }

        // Helper method to generate the product list in plain text format
        private string GenerateProductListText(IEnumerable<Product> products)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Product List");
            sb.AppendLine("------------");

            foreach (var product in products)
            {
                sb.AppendLine($"ID: {product.Id}");
                sb.AppendLine($"Name: {product.Name}");
                sb.AppendLine($"Price: {product.Price:C}");
                sb.AppendLine(); // Empty line between products
            }

            return sb.ToString();
        }
    }
}