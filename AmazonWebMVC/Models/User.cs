using System.ComponentModel.DataAnnotations;

namespace AmazonWebMVC.Models
{
    public class User{
    [Required]
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    private static int lastUserID = 0;

    // Constructor
    public User(string name, string email, string password, DateTime createdAt)
    {
        UserID = ++lastUserID;
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
    }

    // Method to display User info
    public void DisplayUserInfo()
    {
        Console.WriteLine($"UserID: {UserID}, Name: {Name}, Email: {Email}, CreatedAt: {CreatedAt}");
    }
    }}