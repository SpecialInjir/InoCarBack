using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class RefreshTokenConfiguration
    {

        public static void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<RefreshToken>()
                .Property(x => x.Id)
                .IsRequired();

            builder.Entity<RefreshToken>()
              .Property(x => x.Token)
              .IsRequired();


            builder.Entity<RefreshToken>()
              .Property(x => x.IsActive)
              .IsRequired();

            builder.Entity<RefreshToken>()
              .Property(x => x.CreatedDate)
              .IsRequired();

            builder.Entity<RefreshToken>()
            .Property(x => x.UpdatedDate)
            .IsRequired();

            builder.Entity<RefreshToken>()
             .HasOne(x => x.User)
              .WithMany(x => x.RefreshTokens)
              .HasForeignKey(x => x.UserId)
              .IsRequired();

             
    }
    }
}
