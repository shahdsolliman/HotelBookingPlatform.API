using HotelBookingPlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Infrastructure.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUsers, IdentityRole<Guid>, Guid>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<HotelBookingPlatform.Core.Entities.Business.Address>();
            modelBuilder.Ignore<HotelBookingPlatform.Core.Entities.Business.Bookings>();
            modelBuilder.Ignore<HotelBookingPlatform.Core.Entities.Business.Hotels>();
            modelBuilder.Ignore<HotelBookingPlatform.Core.Entities.Business.Rooms>();
        }

        public DbSet<AppUsers> AppUsers { get; set; }

    }
}
