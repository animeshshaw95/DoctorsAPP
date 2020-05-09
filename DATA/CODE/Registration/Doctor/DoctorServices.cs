using CORE.CODE;
using CORE.CODE.Registration.Doctor;
using CORE.DATAMODEL.Doctor;
using DATA.DATACONNECTION;
using DATA.DBACCESSMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE.Registration.Doctor
{
    public class DoctorServices : IDoctorServices
    {
        #region Global Variable
        private readonly DataConnection DB;
        private readonly DoctorsDBAccessModel DDAM;
        #endregion

        #region CTOR
        public DoctorServices(IGlobal _global)
        {
            DB = new DataConnection();
            DDAM = new DoctorsDBAccessModel(_global);
        }
        #endregion
        public DoctorRegistrationResponse RegisterDoctor(DoctorRegistration Req)
        {
            DoctorRegistrationResponse _resp = new DoctorRegistrationResponse();
            try
            {

            }
            catch(Exception ex) {
                _resp.IsError = true;
                _resp.Message = ex.ToString();
            }
            return _resp;
        }
    }
}
