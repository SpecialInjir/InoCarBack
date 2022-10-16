using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class MileageLevelConfiguration
    {
         public static void OnModelCreating(ModelBuilder builder)
        {




            builder.Entity<MileageLevel>()
              .Property(x => x.Id)
              .IsRequired();

            builder.Entity<MileageLevel>()
              .Property(x => x.Mileage)
              .IsRequired();

            builder.Entity<MileageLevel>()
             .Property(x => x.WorkTypes)
             .IsRequired();

            builder.Entity<MileageLevel>()
           .HasOne(x => x.Product)
            .WithMany(x => x.MileageLevels)
            .HasForeignKey(x => x.ProductId)
            .IsRequired();


        }
    }
}
