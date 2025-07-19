using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Business
{
    public enum StarRating
    {
        [EnumMember(Value = "OneStar")]
        OneStar,

        [EnumMember(Value = "Two Stars")]
        TwoStars,

        [EnumMember(Value = "Three Stars")]
        ThreeStars,

        [EnumMember(Value = "Four Stars")]
        FourStars,

        [EnumMember(Value = "Five Stars")]
        FiveStars
    }
}
