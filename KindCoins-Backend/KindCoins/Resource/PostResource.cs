using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Resource;

public class PostResource
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public string Url { get; set; }
    public string Photo { get; set; }
    public int Likes { get; set; }
    public int Shares { get; set; }
    public User User { get; set; }
}