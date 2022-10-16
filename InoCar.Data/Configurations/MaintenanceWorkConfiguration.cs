using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class MaintenanceWorkConfiguration
    {

        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MaintenanceWork>()
                .Property(x => x.Id)
                .IsRequired();


            builder.Entity<MaintenanceWork>()
              .Property(x => x.Description)
               .HasMaxLength(100)
              .IsRequired();


            builder.Entity<MaintenanceWork>()
              .Property(x => x.Price)
               .HasMaxLength(6)
              .IsRequired();


            builder.Entity<MaintenanceWork>()
             .Property(x => x.ExploitationMonths)
             .IsRequired();

            builder.Entity<MaintenanceWork>()
            .Property(x => x.IsDeleted)
            .IsRequired();

            builder.Entity<MaintenanceWork>()
            .HasOne(x => x.VisitReason)
             .WithMany(x => x.MaintenanceWorks)
             .HasForeignKey(x => x.VisitReasonId)
             .IsRequired();

            builder.Entity<MaintenanceWork>()
             .HasMany(x => x.Products)
             .WithOne(x => x.MaintenanceWork)
             .HasForeignKey(x => x.MaintenanceWorkId)
             .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
