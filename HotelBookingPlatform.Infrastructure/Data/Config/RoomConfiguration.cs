using HotelBookingPlatform.Core.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Infrastructure.Data.Config
{
    public class RoomConfiguration : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Description)
                .IsRequired();

            builder.Property(r => r.Capacity)
                .IsRequired();

            builder.Property(r => r.PricePerNight)
                .HasColumnType("decimal(18,2)");

            builder.Property(r => r.RoomType)
                   .HasConversion(new EnumToStringConverter<RoomType>());

            builder.HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);
        }
    }
}
