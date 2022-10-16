using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class CarConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Entity<Car>()
                .Property(x => x.Id)
                .IsRequired();


            builder.Entity<Car>()
               .Property(x => x.Mark)
               .HasMaxLength(60)
               .IsRequired();

            builder.Entity<Car>()
               .Property(x => x.Model)
                .HasMaxLength(60)
               .IsRequired();

            builder.Entity<Car>()
               .Property(x => x.Year)
               .IsRequired();

            builder.Entity<Car>()
               .Property(x => x.StateNumber)
                .HasMaxLength(10)
               .IsRequired();

            builder.Entity<Car>()
               .Property(x => x.Transmission)
               .IsRequired(false);

            builder.Entity<Car>()
              .Property(x => x.EngineType)
              .IsRequired(false);

            builder.Entity<Car>()
              .Property(x => x.Drive)
               .HasMaxLength(60)
              .IsRequired(false);


            builder.Entity<Car>()
              .Property(x => x.Mileage)
              .IsRequired();

            builder.Entity<Car>()
              .Property(x => x.ImgUrl)
              .IsRequired(false);

            builder.Entity<Car>()
              .Property(x => x.IsDeleted)
              .IsRequired();


            builder.Entity<Car>()
              .HasOne(x => x.CarCertificate)
              .WithOne(x => x.Car)
              .HasForeignKey<Car>(x => x.CertificateId);

            builder.Entity<Car>()
              .HasOne(x => x.RemoveCarReason)
              .WithMany(x => x.Cars)
              .HasForeignKey(p => p.RemoveCarReasonId)
              .OnDelete(DeleteBehavior.NoAction);


        }
    }
}