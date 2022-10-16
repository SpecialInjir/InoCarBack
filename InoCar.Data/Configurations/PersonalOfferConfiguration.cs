using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class PersonalOfferConfiguration
    {

        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonalOffer>()
              .Property(x => x.Id)
              .IsRequired();

            builder.Entity<PersonalOffer>()
              .Property(x => x.Description)
              .IsRequired();

            builder.Entity<PersonalOffer>()
             .Property(x => x.Discount)
             .IsRequired();

            builder.Entity<PersonalOffer>()
             .Property(x => x.EndDate)
             .IsRequired();

            builder.Entity<PersonalOffer>()
            .Property(x => x.IsDeleted)
            .IsRequired();

            builder.Entity<PersonalOffer>()
             .HasMany(x => x.Products)
             .WithOne(x => x.PersonalOffer)
             .HasForeignKey(x => x.PersonalOfferId)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
