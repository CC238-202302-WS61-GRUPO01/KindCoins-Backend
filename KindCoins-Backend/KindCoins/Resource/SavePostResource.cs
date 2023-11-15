namespace KindCoins_Backend.KindCoins.Resource;

public class SavePostResource
{
    public string Comment { get; set; }
    public string Url { get; set; }
    public string Photo { get; set; }
    public int Likes { get; set; }
    public int Shares { get; set; }
    public int UserId { get; set; }
}