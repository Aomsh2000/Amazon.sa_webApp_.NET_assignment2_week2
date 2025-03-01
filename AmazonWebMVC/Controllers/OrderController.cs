using Microsoft.AspNetCore.Mvc;
using AmazonWebMVC.Models;

namespace AmazonWebMVC.Controllers
{
    public class OrderController : Controller
    {
       
          private static List<Product> _products = new List<Product>
        {
            new Product(1, "Laptop", "Electronics", 999, 50),
            new Product(2, "Shirt", "Clothing", 29, 200),
            new Product(3, "Smartphone", "Electronics", 599, 150),
            new Product(4, "Coffee Maker", "Appliances", 79, 75)
        };
        private static List<Order> _orders = new List<Order>{};

        // Display the order form
        public IActionResult CreateOrder()
        {
          
            return View(_products);
        }

       
        [HttpPost]
        public IActionResult CreateOrder(int userID, List<int> productIDs, List<int> quantities)
        {
            if (productIDs.Count != quantities.Count)
            {
                
                return BadRequest("Product IDs and Quantities must match.");
            }

            

            // Create a new order
            Order newOrder = new Order(userID);

            double totalAmount = 0;

            for (int i = 0; i < productIDs.Count; i++)
            {
                var product = _products.FirstOrDefault(p => p.ProductID == productIDs[i]);

                if (product != null && product.StockQuantity >= quantities[i])
                {
                    OrderDetails orderDetail = new OrderDetails(newOrder.OrderID,product.ProductID,quantities[i], product.Price * quantities[i]);

                    newOrder.OrderDetail.Add(orderDetail);
                    totalAmount += orderDetail.SubTotal;

                    // Update product stock after order
                    product.StockQuantity -= quantities[i];
                }
                else
                {
                    return BadRequest($"Insufficient stock for product {productIDs[i]}.");
                }
            }

            newOrder.TotalAmount = totalAmount;
            _orders.Add(newOrder);
            // save the order 
            return View("OrderConfirmation", newOrder);
        }

        public IActionResult ViewOrderDetails(int orderID)
            {
                var order = _orders.FirstOrDefault(o => o.OrderID == orderID);
                if (order == null)
                {
                    return NotFound("Order not found.");
                }

                return View("ViewOrderDetails",order);
            }
    }
}
