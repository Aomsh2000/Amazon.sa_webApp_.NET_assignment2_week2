using Microsoft.AspNetCore.Mvc;
using AmazonWebMVC.Models;

namespace AmazonWebMVC.Controllers
{
    //[Route("Products")]
    public class ProductController : Controller
    {
        
        private static List<Product> _products = new List<Product>
        {
            new Product(1, "Laptop", "Electronics", 999, 50),
            new Product(2, "Shirt", "Clothing", 29, 200),
            new Product(3, "Smartphone", "Electronics", 599, 150),
            new Product(4, "Coffee Maker", "Appliances", 79, 75)
        };

        // display the product list
       // [HttpGet]
        public IActionResult Index()
        {
            return View(_products);
        }
    }
}
