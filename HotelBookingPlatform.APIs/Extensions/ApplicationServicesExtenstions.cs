using HotelBookingPlatform.APIs.Helpers;
using HotelBookingPlatform.Application;
using HotelBookingPlatform.Core;
using HotelBookingPlatform.Core.Repositories.Contract;
using HotelBookingPlatform.Core.Services.Contract;
using HotelBookingPlatform.Infrastructure;
using HotelBookingPlatform.Infrastructure.Data;
using HotelBookingPlatform.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnapShop.API.Errors;

namespace HotelBookingPlatform.APIs.Extensions
{
    public static class ApplicationServicesExtenstions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBuiltInServices();
            services.AddSwaggerServices();
            services.AddUserDefinedServices();
            services.AddDbContextServices(configuration);
            services.AddIdentityDbContextServices(configuration);
            services.AddAutoMapperServices();
            services.ConfigureInValidResponseServices();
            // services.AddRedisServices(configuration);

            return services;
        }

        private static IServiceCollection AddBuiltInServices(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        private static IServiceCollection AddUserDefinedServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHotelSevice, HotelService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBookingService, BookingService>();
            return services;
        }

        private static IServiceCollection ConfigureInValidResponseServices(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
               options.InvalidModelStateResponseFactory = (ActionContext) =>
               {
                   var errors = ActionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                                        .SelectMany(E => E.Value.Errors)
                                                        .Select(E => E.ErrorMessage)
                                                        .ToArray();
                   var response = new ApiValidationErrorResponse
                   {
                       Errors = errors
                   };

                   return new BadRequestObjectResult(response);
               }
            );
            return services;
        }

        private static IServiceCollection AddIdentityDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            var identityConnectionString = configuration.GetConnectionString("IDENTITY_CONNECTION_STRING");

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(identityConnectionString));

            return services;
        }

        private static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            var businessConnectionString = configuration.GetConnectionString("BUSINESS_CONNECTION_STRING");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(businessConnectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            return services;
        }

        private static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            return services;
        }
    }
}
