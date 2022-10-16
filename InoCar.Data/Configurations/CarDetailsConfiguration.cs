using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class CarDetailsConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CarDetails>()
                .Property(x => x.Id)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.CertificateId)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.DaysBeforeTO)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.ReminderOfMaintenance)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.ReminderOfTO)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.MileageToTO)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.WarrantyEndDate)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.ServiceCampaigns)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.LastVisitTO)
                .IsRequired();

            builder.Entity<CarDetails>()
                .Property(x => x.KmBeforeTO)
                .IsRequired();


            builder.Entity<CarDetails>()
             .HasOne(x => x.CarCertificate)
             .WithOne(x => x.CarDetails)
             .HasForeignKey<CarDetails>(x => x.CertificateId)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}