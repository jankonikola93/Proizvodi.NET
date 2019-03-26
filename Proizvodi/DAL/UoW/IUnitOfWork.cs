using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;
        void Save();
        void LogError(string error);
    }
}
