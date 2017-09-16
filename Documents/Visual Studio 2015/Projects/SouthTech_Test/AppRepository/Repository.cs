using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AppLogger;
namespace AppRepository
{
   public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region vars
        private readonly DbContext context;
        #endregion
        #region Ctor
        public Repository(DbContext _context)
        {
            this.context = _context;
        }
        #endregion
        #region Func
        public int Create(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Add(obj);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public async Task<int> CreateAsync(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Add(obj);
                var result= await context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public int Delete(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Remove(obj);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public async Task<int> DeleteAsync(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Remove(obj);
                var result=await context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> match)
        {
            try
            {
                return context.Set<TEntity>().Where(match).ToList();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            try
            {
                return await context.Set<TEntity>().Where(match).ToListAsync();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public TEntity GetByID(int Id)
        {
            try
            {
                return context.Set<TEntity>().Find(Id);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public async Task<TEntity> GetByIDAsync(int Id)
        {
            try
            {
                return await context.Set<TEntity>().FindAsync(Id);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public int Update(TEntity obj, int Id)
        {
            try
            {
                if (obj!=null)
                {
                    TEntity Data = context.Set<TEntity>().Find(Id);
                    if (Data!=null)
                    {
                        context.Entry(Data).CurrentValues.SetValues(obj);
                        return context.SaveChanges();
                    }
                }
               
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public async Task<int> UpdateAsync(TEntity obj, int Id)
        {
            try
            {
                if (obj != null)
                {
                    TEntity Data =await context.Set<TEntity>().FindAsync(Id);
                    if (Data != null)
                    {
                        context.Entry(Data).CurrentValues.SetValues(obj);
                        var result=await context.SaveChangesAsync();
                        return result;
                    }
                }

            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Repository<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        } 
        #endregion
    }
}
