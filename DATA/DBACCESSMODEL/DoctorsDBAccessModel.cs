using CORE.CODE;
using CORE.DATAMODEL;
using DATA.DATACONNECTION;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DBACCESSMODEL
{
    public class DoctorsDBAccessModel
    {
        #region Global Variable

        DataConnection DB;
        SqlServerParamManager _parameterManager;
        private readonly IGlobal Global;

        #endregion
        #region CTOR
        public DoctorsDBAccessModel(IGlobal _global)
        {
            Global = _global;
            DB = new DataConnection();
            _parameterManager = new SqlServerParamManager();
        }
        #endregion

        public DbDataReader GETDoctorTypes()
        {
            try
            {
                return DB.ExecuteStoredProcedureForReader("USP_DoctorTypes_GET", Global.ConnectionString().ToString(), null);
            }
            catch (Exception ex) { throw ex; }
        }
        public DbDataReader InsertDoctorProfile(DoctorInsertModel req)
        {
            try
            {
                return DB.ExecuteStoredProcedureForReader("USP_Doctors_InsertUpdate", Global.ConnectionString().ToString(),
                                                                _parameterManager.Get("@inFirstName",req.FirstName)
                                                                ,_parameterManager.Get("@inLastName", req.LastName)
                                                                , _parameterManager.Get("@inEmail", req.Email)
                                                                , _parameterManager.Get("@inPhoneNumer", req.PhoneNumber)
                                                                , _parameterManager.Get("@inAddress", req.Address)
                                                                , _parameterManager.Get("@inCountry", req.Country)
                                                                , _parameterManager.Get("@inState", req.State)
                                                                , _parameterManager.Get("@inPincode", req.Pincode)
                                                                , _parameterManager.Get("@inImage", req.Image)
                                                                , _parameterManager.Get("@inPassword", req.Password)
                                                                , _parameterManager.Get("@inUserType", UserTypes.Doctor)
                                                                , _parameterManager.Get("@inDoctorTypes", String.Join(",",req.DoctorTypes))
                                                                , _parameterManager.Get("@inMode", Mode.Insert)
                                                                , _parameterManager.Get("@inID", 0)
                                                                );
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
