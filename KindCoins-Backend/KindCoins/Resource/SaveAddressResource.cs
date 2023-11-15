namespace KindCoins_Backend.KindCoins.Resource;

public class SaveAddressResource
{
    public string  AddressName { get; set; }
    public string Reference { get; set; }
    public int DistrictId { get; set; }
    public int CampaignId { get; set; }
}