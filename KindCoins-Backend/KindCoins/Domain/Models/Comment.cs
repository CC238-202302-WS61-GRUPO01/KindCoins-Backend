namespace KindCoins_Backend.KindCoins.Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
    
    //Relationships
    
    public int PostId { get; set; }
    public int UserId { get; set; }
    public Post Post { get; set; }
    public User User { get; set; }
}