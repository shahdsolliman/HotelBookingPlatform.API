using HotelBookingPlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Services.Contract
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUsers user, UserManager<AppUsers> userManager);
    }
}
