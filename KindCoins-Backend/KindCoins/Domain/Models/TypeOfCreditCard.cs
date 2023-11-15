using System.Text.Json.Serialization;

namespace KindCoins_Backend.KindCoins.Domain.Models;

public class TypeOfCreditCard
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public IList<PaymentData> PaymentDatas { get; set; } = new List<PaymentData>();
}