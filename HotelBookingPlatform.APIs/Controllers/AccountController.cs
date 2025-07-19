using HotelBookingPlatform.APIs.DTOs;
using HotelBookingPlatform.APIs.Helpers;
using HotelBookingPlatform.Core.Entities.Identity;
using HotelBookingPlatform.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SnapShop.API.Errors;
using System.Security.Claims;

namespace HotelBookingPlatform.APIs.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        
        [HttpPost("login")] //POST: api/account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            // Check ModelState
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
            // Generate JWT token
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = loginDto.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

        [HttpPost("register")] //POST: api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUsers()
            {
                DisplayName = registerDto.DisplayName,
                UserName = registerDto.Email,
                Email = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = registerDto.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

        //[CachedAttribute(60)]
        [Authorize]
        [HttpGet] //GET: /api/account
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
                return Unauthorized("Email claim not found");

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

    }
}
