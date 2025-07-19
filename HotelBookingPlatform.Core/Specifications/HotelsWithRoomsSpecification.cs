using HotelBookingPlatform.Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Specifications
{
    public class HotelsWithRoomsSpecification : BaseSpecifications<Hotels>
    {
        public HotelsWithRoomsSpecification(HotelSpecParams specParams)
            : base(h =>
            (string.IsNullOrEmpty(specParams.Search) || h.Name.ToLower().Contains(specParams.Search)) &&
            (string.IsNullOrEmpty(specParams.City) || h.Address.City.ToLower() == specParams.City.ToLower()) &&
            (!specParams.StarRating.HasValue || (int)h.StarRating == specParams.StarRating))
        {
            Includes.Add(h => h.Rooms);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(h => h.Name);
                        break;

                    case "nameDesc":
                        AddOrderByDesc(h => h.Name);
                        break;

                    case "ratingAsc":
                        AddOrderBy(h => h.StarRating);
                        break;

                    case "ratingDesc":
                        AddOrderByDesc(h => h.StarRating);
                        break;

                    default:
                        AddOrderBy(h => h.Name);
                        break;
                }
            }
            else
                AddOrderBy(h => h.Name);

            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }

        public HotelsWithRoomsSpecification(Guid id)
            :base(h => h.Id == id)
        {
            Includes.Add(h => h.Rooms);
        }
    }
}
