using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class VisitReasonConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VisitReason>()
             .Property(x => x.Id)
             .IsRequired();


            builder.Entity<VisitReason>()
            .Property(x => x.Description)
            .IsRequired();

            builder.Entity<VisitReason>()
            .Property(x => x.IsDeleted)
            .IsRequired();
            
            builder.Entity<VisitReason>()
           .HasMany(x => x.MaintenanceWorks)
           .WithOne(x => x.VisitReason)
           .HasForeignKey(x => x.VisitReasonId)
           .OnDelete(DeleteBehavior.Cascade);

        }
    }

}