using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class UserConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder) {

           

            builder.Entity<User>()
               .Property(x => x.LastName)
               .HasMaxLength(60)
               .IsRequired();

            builder.Entity<User>()
              .Property(x => x.FirstName)
              .HasMaxLength(60)
              .IsRequired();

            builder.Entity<User>()
              .Property(x => x.Patronymic)
              .HasMaxLength(60)
              .IsRequired(false);

           

            builder.Entity<User>()
              .Property(x => x.DateBirth)
              .IsRequired();

            builder.Entity<User>()
              .Property(x => x.City)
              .HasMaxLength(100)
              .IsRequired(false);


            builder.Entity<User>()
                .HasMany(x => x.RefreshTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
            .HasMany(x => x.ResetPasswordCodes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<User>()
              .HasMany(x => x.CarCertificates)
              .WithOne(x => x.User)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
             .HasMany(x => x.ServiceRequests)
             .WithOne(x => x.User)
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<User>()
            //   .HasMany(x => x.UserCodes) // юзер может иметь много кодов
            //   .WithOne(x => x.User) // у кода только один владелец юзер
            //   .HasForeignKey(x => x.UserId) // внешний ключ у таблицы UserCode
            //   .OnDelete(DeleteBehavior.Cascade) //  при удалении юзера удалятся все его коды
            //   .IsRequired(false);


        }

    }
}
