using SimaApp.Application.Interfaces.Repositories;
using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class,IEntityBase,new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class,IEntityBase,new();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
