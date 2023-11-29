namespace AllWeKnow.App.Database.Models;

public class User
{
    public int Id { get; set; }
    public string? Fullname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Rights { get; set; }
    public string? Type { get; set; }
}