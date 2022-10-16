using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class RecommendationServiceRequestConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecommendationServiceRequest>()
                .Property(x => x.Id)
                .IsRequired();


            builder.Entity<RecommendationServiceRequest>()
            .HasOne(x => x.Recommendation)
            .WithMany(x => x.RecommendationServiceRequests)
            .HasForeignKey(x => x.RecommendationId)
            .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<RecommendationServiceRequest>()
              .HasOne(x => x.ServiceRequest)
              .WithMany(x => x.RecommendationServiceRequests)
              .HasForeignKey(x => x.ServiceRequestId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
