using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class ServiceConsultantConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ServiceConsultant>()
              .Property(x => x.Id)
              .IsRequired();

            builder.Entity<ServiceConsultant>()
             .Property(x => x.FirstName)
             .IsRequired();

            builder.Entity<ServiceConsultant>()
             .Property(x => x.LastName)
             .IsRequired();


            builder.Entity<ServiceConsultant>()
             .Property(x => x.IsDeleted)
             .IsRequired();

            builder.Entity<ServiceConsultant>()
             .HasOne(x => x.Dealership)
              .WithMany(x => x.ServiceConsultants)
              .HasForeignKey(x => x.DealershipId)
              .IsRequired();


            builder.Entity<ServiceConsultant>()
                .HasMany(x => x.TimeSlots)
                .WithOne(x => x.ServiceConsultant)
                .HasForeignKey(x => x.ServiceConsultantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}