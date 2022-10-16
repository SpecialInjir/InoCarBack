using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class RemoveCarReasonConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RemoveCarReason>()
             .Property(x => x.Id)
             .IsRequired();


            builder.Entity<RemoveCarReason>()
            .Property(x => x.Description)
            .IsRequired();

            builder.Entity<RemoveCarReason>()
           .Property(x => x.Type)
           .IsRequired();
            
            builder.Entity<RemoveCarReason>()
           .Property(x => x.IsDeleted)
           .IsRequired();

            builder.Entity<RemoveCarReason>()
           .HasMany(x => x.Cars)
           .WithOne(x => x.RemoveCarReason)
           .HasForeignKey(x => x.RemoveCarReasonId)
           .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
