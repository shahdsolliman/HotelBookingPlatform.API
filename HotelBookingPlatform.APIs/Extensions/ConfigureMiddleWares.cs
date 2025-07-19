using HotelBookingPlatform.APIs.MiddleWares;
using HotelBookingPlatform.Core.Entities.Identity;
using HotelBookingPlatform.Infrastructure.Data;
using HotelBookingPlatform.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingPlatform.APIs.Extensions
{
    public static class ConfigureMiddleWares
    {
        public static async Task<WebApplication> ConfigureMiddleWaresAsync(this WebApplication app)
        {
            #region Apply Migrations & Seeding

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var dbContext = services.GetRequiredService<AppDbContext>();
            var identityContext = services.GetRequiredService<AppIdentityDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUsers>>();

            try
            {
                //await dbContext.Database.MigrateAsync();
                //await AppDbContextSeeding.SeedAsync(dbContext, userManager);

                //await identityContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during database migration");
            }

            #endregion

            #region Configure Middlewares

            app.UseMiddleware<ExceptionMiddleware>();

            // Swagger only in development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            // Disable HTTPS redirection on Railway
            // Railway handles HTTPS externally
            // app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            #endregion

            return app;
        }
    }
}
