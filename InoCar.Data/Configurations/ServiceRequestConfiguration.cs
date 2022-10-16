using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class ServiceRequestConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ServiceRequest>()
                .Property(x => x.Id)
                .IsRequired();


            builder.Entity<ServiceRequest>()
               .Property(x => x.City)
               .HasMaxLength(60)
               .IsRequired();

            builder.Entity<ServiceRequest>()
              .Property(x => x.Comment)
              .HasMaxLength(1000)
              .IsRequired();

            builder.Entity<ServiceRequest>()
             .Property(x => x.Mileage)
             .IsRequired();

            builder.Entity<ServiceRequest>()
            .Property(x => x.IsCompleted)
            .IsRequired();

            builder.Entity<ServiceRequest>()
            .Property(x => x.IsRequestConfirm)
            .IsRequired();


            builder.Entity<ServiceRequest>()
             .Property(x => x.CreateRequestDate)
             .HasDefaultValue(DateTime.Now)
             .IsRequired();


            builder.Entity<ServiceRequest>()
                .HasOne(x => x.Dealership)
                .WithMany(x => x.ServiceRequests)
                .HasForeignKey(p => p.DealershipId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<ServiceRequest>()
              .HasOne(x => x.ServiceConsultant)
              .WithMany(x => x.ServiceRequests)
              .HasForeignKey(p => p.ServiceConsultantId)
              .OnDelete(DeleteBehavior.NoAction);

       

            builder.Entity<ServiceRequest>()
                .HasOne(x => x.TimeSlot)
                .WithMany(x => x.ServiceRequests)
                .HasForeignKey(p => p.TimeSlotId)
                .OnDelete(DeleteBehavior.NoAction);



            //builder.Entity<ServiceRequest>()
            //    .HasOne(x => x.VisitReason)
            //    .WithOne(x => x.ServiceRequest)
            //    .HasForeignKey<ServiceRequest>(p => p.VisitReasonId)
            //    .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<ServiceRequest>()
                .HasOne(x => x.VisitReason)
                .WithMany(x => x.ServiceRequests)
                .HasForeignKey(p => p.VisitReasonId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<ServiceRequest>()
                .HasOne(x => x.Car)
                .WithMany(x => x.ServiceRequests)
                .HasForeignKey(p => p.CarId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<ServiceRequest>()
             .HasOne(x => x.User)
              .WithMany(x => x.ServiceRequests)
              .HasForeignKey(x => x.UserId)
              .IsRequired();

         

      

            //builder.Entity<ServiceRequest>()
            //   .HasOne(x => x.RecommendationServiceRequest)
            //   .WithOne(x => x.ServiceRequest)
            //   .HasForeignKey<ServiceRequest>(p => p.RecommendationServiceRequestId)
            //   .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ServiceRequest>()
            // .HasOne(x => x.PersonalOfferServiceRequest)
            // .WithOne(x => x.ServiceRequest)
            // .HasForeignKey<ServiceRequest>(p => p.PersonalOfferServiceRequestId)
            // .OnDelete(DeleteBehavior.NoAction);


            //builder.Entity<User>()
            //   .HasMany(x => x.UserCodes) // юзер может иметь много кодов
            //   .WithOne(x => x.User) // у кода только один владелец юзер
            //   .HasForeignKey(x => x.UserId) // какой внешний ключ у таблицы UserCode
            //   .OnDelete(DeleteBehavior.Cascade) //  при удалении юзера удалятся все его коды
            //   .IsRequired(false);


        }
    }
}
