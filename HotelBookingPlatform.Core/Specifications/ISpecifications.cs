using HotelBookingPlatform.Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>> Criteria { get; set; } // Represents the filter criteria for the specification (WHERE clause in SQL)
        public List<Expression<Func<T, object>>> Includes { get; set; } // Represents The INCLUDES

    }
}
