using HotelBookingPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Business
{
    public class Hotels : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public StarRating StarRating { get; set; }

        public ICollection<Rooms> Rooms { get; set; } = new HashSet<Rooms>(); // Navigation property One-to-Many relationship with Room
    }
}
