using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class DealershipFeedbackConfuguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<DealershipFeedback>()
                .Property(x => x.Id)
                .IsRequired();

            builder.Entity<DealershipFeedback>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<DealershipFeedback>()
                .Property(x => x.PointNumber)
                .IsRequired();

            builder.Entity<DealershipFeedback>()
                .Property(x => x.Comment)
                .HasMaxLength(2000)
                .IsRequired(false);

            builder.Entity<DealershipFeedback>()
                .Property(x => x.PublicDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.Entity<DealershipFeedback>()
                .HasOne(x => x.Dealership)
                .WithMany(x => x.DealershipFeedbacks)
                .HasForeignKey(x => x.DealershipId)
                .IsRequired();
        }
    }
}
