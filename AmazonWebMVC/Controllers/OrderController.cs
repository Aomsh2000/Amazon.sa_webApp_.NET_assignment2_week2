using Microsoft.AspNetCore.Mvc;
using AmazonWebMVC.Models;

namespace AmazonWebMVC.Controllers
{
    [Route("Orders")]
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
            
            // Ensure the input is valid
             if (!ModelState.IsValid)
            {
                return View("CreateOrder", _products); // Return the form with error messages
            }

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
               // GET /Orders/{userId}
        [HttpGet("{userId}")]
        public IActionResult OrderHistory(int userId)
        {
            var userOrders = _orders.Where(o => o.UserID == userId).ToList();
            if (userOrders.Any())
            {
                return View(userOrders); // Return the view with orders for the specific user
            }
            else
            {
                return NotFound($"No orders found for User ID {userId}.");
            }
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
