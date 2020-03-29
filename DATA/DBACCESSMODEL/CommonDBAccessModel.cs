using CORE.CODE;
using DATA.DATACONNECTION;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DBACCESSMODEL
{
    public class CommonDBAccessModel
    {
        #region Global Variable

        DataConnection DB;
        SqlServerParamManager _parameterManager;
        private readonly IGlobal Global;

        #endregion
        #region CTOR
        public CommonDBAccessModel(IGlobal _global)
        {
            Global = _global;
            DB = new DataConnection();
            _parameterManager = new SqlServerParamManager();
        }
        #endregion

        public DbDataReader GETSpecializations()
        {
            try
            {
                return DB.ExecuteStoredProcedureForReader("usp_GetSpecialization", Global.ConnectionString().ToString(), null);
            }
            catch (Exception ex) { throw ex; }
        }
        public DbDataReader GETStates()
        {
            try
            {
                return DB.ExecuteStoredProcedureForReader("usp_GetStates", Global.ConnectionString().ToString(), null);
            }
            catch (Exception ex) { throw ex; }
        }
        public DbDataReader GETCities(string StateCode)
        {
            try
            {
                return DB.ExecuteStoredProcedureForReader("usp_GetCities", Global.ConnectionString().ToString(), _parameterManager.Get("@inStateCode", StateCode));
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
