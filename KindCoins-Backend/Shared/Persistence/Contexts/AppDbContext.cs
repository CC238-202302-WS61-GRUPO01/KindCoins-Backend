using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<TypeOfDonation> TypeOfDonations { get; set; }
    public DbSet<SuscriptionPlan> SuscriptionPlans { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Donation> Donations { get; set; }
    
    public DbSet<TypeOfCreditCard> TypeOfCreditCards { get; set; }
    
    public DbSet<PaymentData> PaymentDatas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        {
            base.OnModelCreating(builder);

            builder.Entity<Address>().ToTable("Address");
            builder.Entity<Address>().HasKey(p => p.Id);
            builder.Entity<Address>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Address>().Property(p => p.AddressName).IsRequired().HasMaxLength(40);
            builder.Entity<Address>().Property(p => p.Reference).IsRequired().HasMaxLength(40);

            builder.Entity<Country>().ToTable("Country");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.CountryName).IsRequired().HasMaxLength(20);

            builder.Entity<Department>().ToTable("Department");
            builder.Entity<Department>().HasKey(p => p.Id);
            builder.Entity<Department>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Department>().Property(p => p.DepartmentName).IsRequired().HasMaxLength(20);
            
            builder.Entity<District>().ToTable("District");
            builder.Entity<District>().HasKey(p => p.Id);
            builder.Entity<District>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<District>().Property(p => p.DistrictName).IsRequired().HasMaxLength(20);
            
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.DNI).IsRequired().HasMaxLength(8);
            builder.Entity<User>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Photo).HasMaxLength(500);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            
            builder.Entity<Post>().ToTable("Post");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Post>().Property(p => p.Comment).IsRequired().HasMaxLength(500);
            builder.Entity<Post>().Property(p => p.Url).IsRequired().HasMaxLength(500);
            builder.Entity<Post>().Property(p => p.Photo).IsRequired().HasMaxLength(1000);
            builder.Entity<Post>().Property(p => p.Likes).IsRequired().HasMaxLength(500);
            builder.Entity<Post>().Property(p => p.Shares).IsRequired().HasMaxLength(500);

            //Relationships Post with User
            builder.Entity<User>()
                .HasMany(p => p.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            
            //Relationships Address with Campaign
            builder.Entity<Campaign>()
                .HasMany(p => p.Addresses)
                .WithOne(p => p.Campaign)
                .HasForeignKey(p => p.CampaignId);
            
            //Relationship Address with District
            builder.Entity<District>()
                .HasMany(p => p.Addresses)
                .WithOne(p => p.District)
                .HasForeignKey(p => p.DistrictId);
            
            //Relationship District with Department
            builder.Entity<Department>()
                .HasMany(p => p.Districts)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId);
            
            //Relationship Department with Country
            builder.Entity<Country>()
                .HasMany(p => p.Departments)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);
            
            // Relationships SuscriptionPlan with User
            builder.Entity<SuscriptionPlan>()
                .HasMany(p => p.Users)
                .WithOne(p => p.SuscriptionPlan)
                .HasForeignKey(p => p.SuscriptionPlanId);
            
            builder.Entity<SuscriptionPlan>().ToTable("SuscriptionPlan");
            builder.Entity<SuscriptionPlan>().HasKey(p => p.Id);
            builder.Entity<SuscriptionPlan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SuscriptionPlan>().Property(p => p.Plan).IsRequired().HasMaxLength(50);
 
            // Relationships User with Campaign
            builder.Entity<User>()
                .HasMany(p => p.Campaigns)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
 
            builder.Entity<Campaign>().ToTable("Campaign");
            builder.Entity<Campaign>().HasKey(p => p.Id);
            builder.Entity<Campaign>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campaign>().Property(p => p.Name).IsRequired().HasMaxLength(500);
            builder.Entity<Campaign>().Property(p => p.Slogan).IsRequired().HasMaxLength(1000);
            builder.Entity<Campaign>().Property(p => p.HeaderPhoto).IsRequired().HasMaxLength(1000);
            builder.Entity<Campaign>().Property(p => p.AditionalPhoto).IsRequired().HasMaxLength(1000);
            builder.Entity<Campaign>().Property(p => p.Description).HasMaxLength(1000);
            builder.Entity<Campaign>().Property(p => p.Goal).IsRequired();

            builder.Entity<TypeOfDonation>().ToTable("TypeOfDonation");
            builder.Entity<TypeOfDonation>().HasKey(p => p.Id);
            builder.Entity<TypeOfDonation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TypeOfDonation>().Property(p => p.TypeDonation).IsRequired().HasMaxLength(50);
            
            // Relationships TypeOfDonation with Campaign
            builder.Entity<TypeOfDonation>()
                .HasMany(p => p.Campaigns)
                .WithOne(p => p.TypeOfDonation)
                .HasForeignKey(p => p.TypeOfDonationId);
            
            builder.Entity<BankAccount>().ToTable("BankAccount");
            builder.Entity<BankAccount>().HasKey(p => p.Id);
            builder.Entity<BankAccount>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BankAccount>().Property(p => p.AccountNumber).IsRequired().HasMaxLength(15);
            
            // Relationships BankAccount with Campaign
            builder.Entity<Campaign>()
                .HasMany(p => p.BankAccounts)
                .WithOne(p => p.Campaign)
                .HasForeignKey(p => p.CampaignId);
            
            builder.Entity<Donation>().ToTable("Donation");
            builder.Entity<Donation>().HasKey(p => p.Id);
            builder.Entity<Donation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Donation>().Property(p => p.Amount);
            
            //Relationships Donation with User
            builder.Entity<User>()
                .HasMany(p => p.Donations)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            
            //Relationships Donation with Campaign
            builder.Entity<Campaign>()
                .HasMany(p => p.Donations)
                .WithOne(p => p.Campaign)
                .HasForeignKey(p => p.CampaignId);
            
            //Relationships Donation with Type of Donations
            builder.Entity<TypeOfDonation>()
                .HasMany(p => p.Donations)
                .WithOne(p => p.TypeOfDonation)
                .HasForeignKey(p => p.TypeOfDonationId);

            builder.Entity<TypeOfCreditCard>().ToTable("TypeOfCreditCard");
            builder.Entity<TypeOfCreditCard>().HasKey(p => p.Id);
            builder.Entity<TypeOfCreditCard>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TypeOfCreditCard>().Property(p => p.Name);

            builder.Entity<PaymentData>().ToTable("PaymentData");
            builder.Entity<PaymentData>().HasKey(p => p.Id);
            builder.Entity<PaymentData>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentData>().Property(p => p.CardNumber);
            builder.Entity<PaymentData>().Property(p => p.CVV);
            builder.Entity<PaymentData>().Property(p => p.FirstName);
            builder.Entity<PaymentData>().Property(p => p.LastName);
            builder.Entity<PaymentData>().Property(p => p.Email);
            
            //Relationships Payment data with User
            builder.Entity<User>()
                .HasMany(p => p.PaymentDatas)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            
            //Relationships payment data with Type of credit card
            builder.Entity<TypeOfCreditCard>()
                .HasMany(p => p.PaymentDatas)
                .WithOne(p => p.TypeOfCreditCard)
                .HasForeignKey(p => p.TypeOfCreditCardId);
            
            // Apply Snake Case Naming Convention
 
            builder.UseSnakeCaseNamingConvention();
        }

    }
}
