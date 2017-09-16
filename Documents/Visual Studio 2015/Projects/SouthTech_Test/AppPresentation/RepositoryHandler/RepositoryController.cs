using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogger;
using AppRepository;
using AppPresentation.Procedures;
using AppPresentation.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace AppPresentation.RepositoryHandler
{
    public partial class RepositoryController<T> where T : class
    {
        #region var
        private IRepository<T> IRepository;
        #endregion
        #region ctor
        public RepositoryController(IRepository<T> IRepository)
        {
            this.IRepository = IRepository;
        }
        #endregion
        #region Func
        public List<T> ExecuteQuery(Procedures.ExecProcedures.Procedures Query, Dictionary<Enum, object> param)
        {
            string ext = null;
            List<object> objList = new List<object>();
            Enum objEnum = null;
            try
            {
                foreach (var item in param)
                {
                    objList.Add(new SqlParameter() {ParameterName=ext.getParameterValue(item.Key),SqlDbType=objEnum.getSqlDbType(item.Key),Value=item.Value??DBNull.Value });
                }
                return IRepository.ExecuteQuery(ext.getParameterValue(Query), objList.ToArray());
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryController<T>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                return IRepository.GetAll();
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryController<T>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }

        public T GetByID(int Id)
        {
            try
            {
                return IRepository.GetByID(Id);
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<RepositoryController<T>>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }

        #endregion
    }
}
