using HotelBookingPlatform.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnapShop.API.Errors;

namespace HotelBookingPlatform.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public BuggyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            var product = _dbContext.Bookings.Find(42);
            if (product == null)
                return NotFound(new ApiResponse(404));
            return Ok();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var thing = _dbContext.Bookings.Find(42);
            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized(new ApiResponse(401));
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("error", "This is a validation error");
            return ValidationProblem();
        }

    }
}

