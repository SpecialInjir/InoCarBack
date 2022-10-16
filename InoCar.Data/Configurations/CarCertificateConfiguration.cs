using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class CarCertificateConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CarCertificate>()
                .Property(x => x.Id)
                .IsRequired();

          
            builder.Entity<CarCertificate>()
              .Property(x => x.VIN)
               .HasMaxLength(17)
              .IsRequired();

            builder.Entity<CarCertificate>()
              .Property(x => x.SeriaCTC)
               .HasMaxLength(4)
              .IsRequired();

            builder.Entity<CarCertificate>()
              .Property(x => x.NumberCTC)
               .HasMaxLength(6)
              .IsRequired();


             builder.Entity<CarCertificate>()
              .Property(x => x.DateCTC)
              .IsRequired();

            builder.Entity<CarCertificate>()
            .HasOne(x => x.User)
             .WithMany(x => x.CarCertificates)
             .HasForeignKey(x => x.UserId)
             .IsRequired();

            
            builder.Entity<CarCertificate>()
              .HasOne(x => x.Car)
              .WithOne(x => x.CarCertificate)
              .HasForeignKey<Car>(x => x.CertificateId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CarCertificate>()
             .HasOne(x => x.CarDetails)
             .WithOne(x => x.CarCertificate)
             .HasForeignKey<CarDetails>(x => x.CertificateId)
             .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
