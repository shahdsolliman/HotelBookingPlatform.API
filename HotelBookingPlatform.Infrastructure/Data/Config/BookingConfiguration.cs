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
    public class BookingConfiguration : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder.Property(b => b.CheckInDate)
                     .IsRequired()
                     .HasColumnType("datetime");

            builder.Property(b => b.CheckOutDate)
                     .IsRequired()
                     .HasColumnType("datetime");

            builder.Property(b => b.BookingStatus)
                    .HasConversion(new EnumToStringConverter<BookingStatus>());


            //builder.HasOne(b => b.User)
            //       .WithMany(u => u.Bookings)
            //       .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Room)
                   .WithMany(r => r.Bookings)
                   .HasForeignKey(b => b.RoomId);

        }
    }
}
