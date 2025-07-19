using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Business
{
    public enum RoomType
    {
        [EnumMember(Value = "Single")]
        Single,

        [EnumMember(Value = "Double")]
        Double,

        [EnumMember(Value = "Suite")]
        Suite,

        [EnumMember(Value = "Deluxe")]
        Deluxe,

        [EnumMember(Value = "Family")]
        Family
    }
}
