using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace AmazonWebMVC.Models
{
    public class OrderDetails{
    [Required]
    public int OrderDetailID { get; set; }
      [Required(ErrorMessage = "Order ID is required.")]
    public int OrderID { get; set; }
    [Required(ErrorMessage = "Product ID is required.")]
    public int ProductID { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }
    
    public double SubTotal { get; set; }
    
    private static int lastOrderDetailsID = 0;


    // Constructor
    public OrderDetails(int orderID, int productID, int quantity, double subTotal)
    {
        OrderDetailID = ++lastOrderDetailsID;
        OrderID = orderID;
        ProductID = productID;
        Quantity = quantity;
        SubTotal = subTotal;
    }


    }}