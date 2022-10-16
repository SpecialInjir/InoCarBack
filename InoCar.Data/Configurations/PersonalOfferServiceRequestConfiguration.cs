using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class PersonalOfferServiceRequestConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonalOfferServiceRequest>()
                .Property(x => x.Id)
                .IsRequired();


            builder.Entity<PersonalOfferServiceRequest>()
                .HasOne(x => x.PersonalOffer)
                .WithMany(x => x.PersonalOfferServiceRequests)
                .HasForeignKey(x => x.PersonalOfferId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PersonalOfferServiceRequest>()
               .HasOne(x => x.ServiceRequest)
               .WithMany(x => x.PersonalOfferServiceRequests)
               .HasForeignKey(x => x.ServiceRequestId)
               .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
