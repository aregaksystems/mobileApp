using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
  public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetByID(int Id);
        Task<TEntity> GetByIDAsync(int Id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> match);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> match);

        int Create(TEntity obj);
        Task<int> CreateAsync(TEntity obj);

        int Update(TEntity obj,int Id);
        Task<int> UpdateAsync(TEntity obj, int Id);

        int Delete(TEntity obj);
        Task<int> DeleteAsync(TEntity obj);

    }
}
