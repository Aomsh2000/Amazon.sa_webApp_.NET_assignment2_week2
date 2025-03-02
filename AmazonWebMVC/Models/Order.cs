using System.ComponentModel.DataAnnotations;

namespace AmazonWebMVC.Models
{
    public class Order{
        
        public int OrderID { get; set; }
        [Required(ErrorMessage = "User ID is required.")]
        public int UserID { get; set; }
        public List<OrderDetails> OrderDetail { get; set; }
        public double TotalAmount { get; set; }
        private static int lastOrderID = 0;
    // Constructor
    public Order(int userID)
    {
        OrderID = ++lastOrderID;
        UserID = userID;
        OrderDetail = new List<OrderDetails>(); 
    }


    // Method to add an OrderDetail to the order
    public void AddOrderDetail(OrderDetails orderDetail)
    {
        OrderDetail.Add(orderDetail);
    }
        
    }}