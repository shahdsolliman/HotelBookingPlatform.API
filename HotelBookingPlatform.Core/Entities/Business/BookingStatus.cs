using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Business
{
    public enum BookingStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,       // Booking is pending confirmation

        [EnumMember(Value = "Confirmed")]
        Confirmed,     // Booking has been confirmed

        [EnumMember(Value = "Cancelled")]
        Cancelled,     // Guest did not show up for the booking

        [EnumMember(Value = "CheckedIn")]
        CheckedIn,     // Guest has checked in

        [EnumMember(Value = "CheckedOut")]
        CheckedOut     // Guest has checked out
    }
}
