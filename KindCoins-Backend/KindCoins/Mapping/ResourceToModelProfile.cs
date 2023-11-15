using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Resource;

namespace KindCoins_Backend.KindCoins.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCampaignResource, Campaign>();
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveTypeOfDonationResource, TypeOfDonation>();
        CreateMap<SaveSuscriptionPlanResource, SuscriptionPlan>();
        CreateMap<SaveBankAccountResource, BankAccount>();
        CreateMap<SaveAddressResource, Address>();
        CreateMap<SaveCountryResource, Country>();
        CreateMap<SaveDepartmentResource, Department>();
        CreateMap<SaveDistrictResource, District>();
        CreateMap<SavePostResource, Post>();
        CreateMap<DonationResource, Donation>();
        CreateMap<TypeOfCreditCardResource, TypeOfCreditCard>();
        CreateMap<PaymentDataResource, PaymentData>();
    }
}