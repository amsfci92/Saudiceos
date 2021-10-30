using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id);
        TEntity Get(string id);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entiy);
        int AddRange(IEnumerable<TEntity> entities);
        int Update(TEntity entiy);
        int Remove(TEntity entiy);
        int RemoveRange(IEnumerable<TEntity> entities);
        void StopLazyLoad();
        void SaveChanges();
    }
}
