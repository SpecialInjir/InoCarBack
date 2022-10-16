using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Data.Configurations
{
    public class RecommendationConfiguration
    {
        public static void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recommendation>()
                .Property(x => x.Id)
                .IsRequired();

            builder.Entity<Recommendation>()
                .Property(x => x.Description)
                .IsRequired();

            builder.Entity<Recommendation>()
                 .Property(x => x.Price)
                 .IsRequired();


            builder.Entity<Recommendation>()
                 .Property(x => x.IsDeleted)
                 .IsRequired();

        }
    }
}
