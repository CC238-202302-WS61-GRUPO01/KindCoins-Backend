using AutoMapper;
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;
using KindCoins_Backend.KindCoins.Resource;

namespace KindCoins_Backend.KindCoins.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User,UserResource>();
        CreateMap<Campaign, CampaignResource>();
        CreateMap<TypeOfDonation, TypeOfDonationResource>();
        CreateMap<SuscriptionPlan, SuscriptionPlanResource>();
        CreateMap<BankAccount, BankAccountResource>();
        CreateMap<Address, AddressResource>();
        CreateMap<District, DistrictResource>();
        CreateMap<Country, CountryResource>();
        CreateMap<Department, DepartmentResource>();
        CreateMap<Post, PostResource>();
        CreateMap<Donation, DonationResource>();
        CreateMap<TypeOfCreditCard, TypeOfCreditCardResource>();
        CreateMap<PaymentData, PaymentDataResource>();
    }
}