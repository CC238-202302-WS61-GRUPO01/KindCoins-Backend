namespace KindCoins_Backend.KindCoins.Resource;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DNI { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Photo { get; set; }
    
    public SuscriptionPlanResource SuscriptionPlan { get; set; }
}