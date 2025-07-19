using HotelBookingPlatform.Core;
using HotelBookingPlatform.Core.Entities;
using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Repositories.Contract;
using HotelBookingPlatform.Infrastructure.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<string, object>();
        }
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var key = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<TEntity>(_dbContext) /*as GenericRepository<BaseEntity>*/;
                _repositories.Add(key, repository);  // warning because [as] is explicitly casted
            }
            return (IGenericRepository<TEntity>)_repositories[key];
        }

        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();

        public ValueTask DisposeAsync()
            => _dbContext.DisposeAsync();

    }
}
