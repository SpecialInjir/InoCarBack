using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class TimeSlotConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<TimeSlot>()
             .Property(x => x.Id)
             .IsRequired();

        
            builder.Entity<TimeSlot>()
             .Property(x => x.StartTime)
             .IsRequired();

            builder.Entity<TimeSlot>()
             .Property(x => x.EndTime)
             .IsRequired();

            builder.Entity<TimeSlot>()
             .Property(x => x.EndTime)
             .IsRequired();

            builder.Entity<TimeSlot>()
             .Property(x => x.IsDeleted)
             .IsRequired();

            builder.Entity<TimeSlot>()
             .HasOne(x => x.ServiceConsultant)
             .WithMany(x => x.TimeSlots)
             .HasForeignKey(x => x.ServiceConsultantId)
             .IsRequired();


        }
    }
}
