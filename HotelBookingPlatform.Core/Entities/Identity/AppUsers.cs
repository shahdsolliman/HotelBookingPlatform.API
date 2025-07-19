using HotelBookingPlatform.Core.Entities.Business;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Identity
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
        public ICollection<Bookings> Bookings { get; set; }

    }
}
