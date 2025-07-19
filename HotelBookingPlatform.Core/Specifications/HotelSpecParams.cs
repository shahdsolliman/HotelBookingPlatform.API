using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Specifications
{
    public class HotelSpecParams
    {
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int pageSize;
        public int PageSize
        {
            get => pageSize == 0 ? 6 : pageSize; // default if not set
            set => pageSize = (value <= 0) ? 6 : (value > MaxPageSize ? MaxPageSize : value);
        }

        private string? search;
        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

        public string? City { get; set; }

        public int? StarRating { get; set; }

        public string? Sort { get; set; }
    }
}
