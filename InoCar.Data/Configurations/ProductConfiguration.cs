using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class ProductConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>()
                 .Property(x => x.Id)
                 .IsRequired();

            builder.Entity<Product>()
                 .Property(x => x.Name)
                 .IsRequired();

            builder.Entity<Product>()
                 .Property(x => x.Price)
                 .IsRequired();

             builder.Entity<Product>()
                .Property(x => x.IsDeleted)
                .IsRequired();

            builder.Entity<Product>()
                 .HasOne(x => x.MaintenanceWork)
                 .WithMany(x => x.Products)
                 .HasForeignKey(x => x.MaintenanceWorkId)
                 .IsRequired();
;
            builder.Entity<Product>()
                 .HasMany(x => x.MileageLevels)
                 .WithOne(x => x.Product)
                 .HasForeignKey(x => x.ProductId)
                 .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Product>()
                 .HasOne(x => x.PersonalOffer)
                 .WithMany(x => x.Products)
                 .HasForeignKey(x => x.PersonalOfferId)
                 .IsRequired(false);

        }
    }
}
