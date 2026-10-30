using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Application.UnitOfWorks;
using SimaApp.Persistance.Context;
using SimaApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

        public int SaveChanges() => _dbContext.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}
