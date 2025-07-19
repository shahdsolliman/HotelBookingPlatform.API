using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingPlatform.Infrastructure.Data
{
    public class AppDbContextSeeding
    {
        public static async Task SeedAsync(AppDbContext dbContext, UserManager<AppUsers> userManager)
        {
            if (dbContext.Rooms.Any())
            {
                dbContext.Rooms.RemoveRange(dbContext.Rooms);
                await dbContext.SaveChangesAsync();
            }

            if (dbContext.Hotels.Any())
            {
                dbContext.Hotels.RemoveRange(dbContext.Hotels);
                await dbContext.SaveChangesAsync();
            }

            var hotel1Id = Guid.Parse("c77ea359-c4e7-47b4-99c2-062914921183");
            var hotel2Id = Guid.Parse("03dd4f96-1f8d-499b-9717-b8d717289afe");

            var hotel1 = new Hotels
            {
                Id = hotel1Id,
                Name = "Mövenpick Resort El Sokhna",
                Description = "5-star beach resort with Red Sea view and luxury amenities.",
                StarRating = StarRating.FiveStars,
                Address = new Address
                {
                    City = "Ain Sokhna",
                    Country = "Egypt",
                    Street = "Zafarana Road"
                }
            };

            var hotel2 = new Hotels
            {
                Id = hotel2Id,
                Name = "Hilton Alexandria Corniche",
                Description = "4-star hotel with Mediterranean Sea view and private beach.",
                StarRating = StarRating.FourStars,
                Address = new Address
                {
                    City = "Alexandria",
                    Country = "Egypt",
                    Street = "Corniche El Maamoura"
                }
            };

            await dbContext.Hotels.AddRangeAsync(hotel1, hotel2);
            await dbContext.SaveChangesAsync();

            var rooms = new List<Rooms>
            {
                new Rooms
                {
                    Name = "Sea-View",
                    Description = "Spacious room with Red Sea view.",
                    PricePerNight = 2500,
                    Capacity = 2,
                    IsAvailable = true,
                    RoomType = RoomType.Double,
                    HotelId = hotel1Id
                },
                new Rooms
                {
                    Name = "Family-Suite",
                    Description = "Suite suitable for families with kids.",
                    PricePerNight = 3500,
                    Capacity = 4,
                    IsAvailable = true,
                    RoomType = RoomType.Suite,
                    HotelId = hotel1Id
                },
                new Rooms
                {
                    Name = "Standard-Twin",
                    Description = "Comfortable twin beds with modern decor.",
                    PricePerNight = 1800,
                    Capacity = 2,
                    IsAvailable = true,
                    RoomType = RoomType.Double,
                    HotelId = hotel2Id
                }
            };

            await dbContext.Rooms.AddRangeAsync(rooms);
            await dbContext.SaveChangesAsync();
        }
    }
}
