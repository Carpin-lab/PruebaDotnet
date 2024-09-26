using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDotnet.src.interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetOne(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task Delete(int id);
        Task Save();
    }
}