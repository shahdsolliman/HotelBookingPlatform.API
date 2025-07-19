using HotelBookingPlatform.Core.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Infrastructure.Data.Config
{
    internal class HotelConfiguration : IEntityTypeConfiguration<Hotels>
    {
        public void Configure(EntityTypeBuilder<Hotels> builder)
        {
            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Description)
                .HasMaxLength(500);

            builder.Property(h => h.StarRating)
                     .HasConversion(
                           h => h.ToString(),
                           O => (StarRating)Enum.Parse(typeof(StarRating), O)
                     );

            builder.OwnsOne(h => h.Address, Address => Address.WithOwner());
            builder.HasMany(h => h.Rooms)
                   .WithOne(r => r.Hotel)
                   .HasForeignKey(r => r.HotelId)
                   .OnDelete(DeleteBehavior.Cascade); // Ensures that when a hotel is deleted, its rooms are also deleted
        }
    }
}
