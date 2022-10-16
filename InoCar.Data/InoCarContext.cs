using InoCar.Data.Configurations;
using InoCar.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RolesIdentityApp.Models;

namespace InoCar.Data
{
    public class InoCarContext : IdentityDbContext<User>
    {
        private readonly UserManager<User> userManager;
        public InoCarContext(DbContextOptions<InoCarContext> options)
            : base(options)
        {
        }

      
        public DbSet<Car> Cars { get; set; } 
        public DbSet<CarCertificate> CarCertificates { get; set; }
        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ResetPasswordCode> ResetPasswordCodes { get; set; }
        public DbSet<VisitReason> VisitReasons { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<ServiceConsultant> ServiceConsultants { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Recommendation> Recommendations { get; set;}
        public DbSet<RecommendationServiceRequest> RecommendationServiceRequests { get; set; }
        public DbSet<PersonalOffer> PersonalOffers { get; set; }
        public DbSet<PersonalOfferServiceRequest> PersonalOfferServiceRequests { get; set; }
        public DbSet<MaintenanceWork> MaintenanceWorks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MileageLevel> MileageLevels { get; set;}
        public DbSet<RemoveCarReason> RemoveCarReasons { get; set; }
        public DbSet<DealershipFeedback> DealershipFeedbacks { get; set; }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            UserConfiguration.OnModelCreating(builder);
            CarCertificateConfiguration.OnModelCreating(builder);
            CarConfiguration.OnModelCreating(builder);
            CarDetailsConfiguration.OnModelCreating(builder);
            RefreshTokenConfiguration.OnModelCreating(builder);
            ResetPasswordCodeConfiguration.OnModelCreating(builder);
            DealershipConfiguration.OnModelCreating(builder);
            VisitReasonConfiguration.OnModelCreating(builder);
            ServiceConsultantConfiguration.OnModelCreating(builder);
            TimeSlotConfiguration.OnModelCreating(builder);
            ServiceRequestConfiguration.OnModelCreating(builder);
            RecommendationConfiguration.OnModelCreating(builder);
            RecommendationServiceRequestConfiguration.OnModelCreating(builder);
            PersonalOfferConfiguration.OnModelCreating(builder);
            PersonalOfferServiceRequestConfiguration.OnModelCreating(builder);
            MaintenanceWorkConfiguration.OnModelCreating(builder);
            ProductConfiguration.OnModelCreating(builder);
            MileageLevelConfiguration.OnModelCreating(builder);
            RemoveCarReasonConfiguration.OnModelCreating(builder);
            DealershipFeedbackConfuguration.OnModelCreating(builder);
            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin1",
                FirstName = "Admin1",
                LastName = "Admin1",
                Email = "John-old@mail.ru",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("DefaultAdmin1"),
                City = "Admin1",
                EmailConfirmed = true,
                DateBirth = DateTime.UtcNow,
                LockoutEnabled=true,
                NormalizedEmail= "John-old@mail.ru".ToUpper(),
                NormalizedUserName = "Admin1".ToUpper()

            }) ;
            builder.Entity<VisitReason>().HasData(new VisitReason
            {
                Id = 1,
                Description = "Техническое обслуживание",
                Type = Enums.VisitReasonTypes.TechnicalWorkReason,
                 
            }, new VisitReason
            {
                Id = 2,
                Description = "Ремонт кузова",
                Type = Enums.VisitReasonTypes.BodyRepair,
            });
            builder.Entity<RemoveCarReason>().HasData(new RemoveCarReason
            {
                Id = 1,
                Description = "Продажа авто",
                Type = Enums.RemoveCarReasonTypes.CarSalesReason
            });
            base.OnModelCreating(builder);
          

        }

    }
}
