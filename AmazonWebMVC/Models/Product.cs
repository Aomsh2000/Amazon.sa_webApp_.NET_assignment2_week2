using System.ComponentModel.DataAnnotations;

namespace AmazonWebMVC.Models
{
    public class Product{
    [Required]
    public int ProductID { get; set; }
    [Required]
    public string Name { get; set; }
    public string Category { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int StockQuantity { get; set; }

    // Constructor
    public Product(int productID, string name, string category, double price, int stockQuantity)
    {
        ProductID = productID;
        Name = name;
        Category = category;
        Price = price;
        StockQuantity = stockQuantity;
    }
    
}
}