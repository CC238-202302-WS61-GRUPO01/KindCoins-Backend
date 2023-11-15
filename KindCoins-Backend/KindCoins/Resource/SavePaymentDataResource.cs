namespace KindCoins_Backend.KindCoins.Resource;

public class SavePaymentDataResource
{
    public string CardNumber { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string CVV { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int TypeOfCreditCardId { get; set; }
    public int UserId { get; set; }
}