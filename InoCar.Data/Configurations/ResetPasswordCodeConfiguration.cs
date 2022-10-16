using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class ResetPasswordCodeConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ResetPasswordCode>()
            .Property(x => x.Id)
            .IsRequired();

            builder.Entity<ResetPasswordCode>()
              .Property(x => x.Code)
              .IsRequired();


            builder.Entity<ResetPasswordCode>()
              .Property(x => x.IsActive)
              .IsRequired();

            builder.Entity<ResetPasswordCode>()
             .Property(x => x.IsDeleted)
             .IsRequired();

            builder.Entity<ResetPasswordCode>()
              .Property(x => x.CreatedDate)
              .IsRequired();


            builder.Entity<ResetPasswordCode>()
             .HasOne(x => x.User)
             .WithMany(x => x.ResetPasswordCodes)
             .HasForeignKey(x => x.UserId)
             .IsRequired();

        }
    }
}