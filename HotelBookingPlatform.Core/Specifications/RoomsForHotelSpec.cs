using HotelBookingPlatform.Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Specifications
{
    public class RoomsForHotelSpec : BaseSpecifications<Rooms>
    {
        public RoomsForHotelSpec(Guid id) : base(r => r.HotelId == id)
        {
            
        }
    }
}
