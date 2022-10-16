using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class DealershipConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Dealership>()
                .Property(x => x.Id)
                .IsRequired();

            builder.Entity<Dealership>()
              .Property(x => x.Name)
              .IsRequired();

            builder.Entity<Dealership>()
              .Property(x => x.Brand)
              .IsRequired();

            builder.Entity<Dealership>()
              .Property(x => x.Address)
              .IsRequired();

            builder.Entity<Dealership>()
              .Property(x => x.OperatorNum)
              .IsRequired();

            builder.Entity<Dealership>()
              .Property(x => x.OpeningTime) 
              .IsRequired();

            builder.Entity<Dealership>()
              .Property(x => x.ClosingTime)
              .IsRequired();

            builder.Entity<Dealership>()
            .Property(x => x.ImgUrl)
            .IsRequired(false);

            
             builder.Entity<Dealership>()
            .Property(x => x.IsDeleted)
            .IsRequired();

            builder.Entity<Dealership>()
              .HasMany(x => x.ServiceConsultants)
              .WithOne(x => x.Dealership)
              .HasForeignKey(x => x.DealershipId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Dealership>()
            .HasMany(x => x.DealershipFeedbacks)
            .WithOne(x => x.Dealership)
            .HasForeignKey(x => x.DealershipId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}