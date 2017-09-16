using AppLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
  public partial  class RepositoryClient<TEntity> where TEntity:class
    {
        #region vars
        private readonly IRepository<TEntity> repository;
        #endregion
        #region ctor
        public RepositoryClient(IRepository<TEntity> _repository)
        {
            this.repository = _repository;
        }
        #endregion
        #region Func
        public int Create(TEntity obj)
        {
            try
            {
               
                return repository.Create(obj);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public async Task<int> CreateAsync(TEntity obj)
        {
            try
            {

                var result = await repository.CreateAsync(obj);
                return result;
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public int Delete(TEntity obj)
        {
            try
            {
                return repository.Delete(obj);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public async Task<int> DeleteAsync(TEntity obj)
        {
            try
            {
               
                var result = await repository.DeleteAsync(obj);
                return result;
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> match)
        {
            try
            {
                return repository.Find(match);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            try
            {
                return await repository.FindAsync(match);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await repository.GetAllAsync();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public TEntity GetByID(int Id)
        {
            try
            {
                return repository.GetByID(Id);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public async Task<TEntity> GetByIDAsync(int Id)
        {
            try
            {
                return await repository.GetByIDAsync(Id);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return null;
        }

        public int Update(TEntity obj, int Id)
        {
            try
            {
                return repository.Update(obj, Id);

            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }

        public async Task<int> UpdateAsync(TEntity obj, int Id)
        {
            try
            {
                return await repository.UpdateAsync(obj, Id);

            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryClient<TEntity>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
            }
            return 0;
        }
        #endregion
    }
}
