namespace KindCoins_Backend.KindCoins.Domain.Models;

public class PaymentData
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string CVV { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    //Relationships
    public int TypeOfCreditCardId { get; set; }
    public TypeOfCreditCard TypeOfCreditCard { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    //public IList<Donation> Donations { get; set; } = new List<Donation>();
}