using HotelBookingPlatform.APIs.Extensions;

namespace HotelBookingPlatform.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services
                   .AddApplicationServices(builder.Configuration)
                   .AddIdentityServices();

            var app = builder.Build();

            // Run middlewares and seed/migrate
            await app.ConfigureMiddleWaresAsync();

            app.Run();
        }
    }
}
