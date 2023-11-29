namespace AllWeKnow.App.Database.Models;

public class Article
{
    public int Id { get; set; }
    public int Status { get; set; }
    public int CategoryId { get; set; }
    public int CreatorId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? TitleImage { get; set; }
    
    public string? Date { get; set; }
    public string? Content { get; set; }
}