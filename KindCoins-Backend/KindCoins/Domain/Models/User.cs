using System.Collections;
using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Photo { get; set; }
    public string LastName { get; set; }
    public string DNI { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    //Relationships
    [JsonIgnore]
    public IList<Post> Posts { get; set; } = new List<Post>();
    [JsonIgnore]
    public IList<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();
    [JsonIgnore]
    public IList<Donation> Donations { get; set; } = new List<Donation>();
    [JsonIgnore]
    public IList<PaymentData> PaymentDatas { get; set; } = new List<PaymentData>();
    
    public int SuscriptionPlanId { get; set; }
    
    [JsonIgnore]
    public SuscriptionPlan SuscriptionPlan { get; set; }
}