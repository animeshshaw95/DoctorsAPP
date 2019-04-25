using CORE.CODE;
using CORE.DATAMODEL;
using DATA.DATACONNECTION;
using DATA.DBACCESSMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE
{
    public class DoctorRegistrationServices:IDoctorRegistrationServices
    {
        #region Global Variable
        private readonly DataConnection DB;
        private readonly DoctorsDBAccessModel DDAM;
        #endregion

        #region CTOR
        public DoctorRegistrationServices(IGlobal _global)
        {
            DB = new DataConnection();
            DDAM = new DoctorsDBAccessModel(_global);
        }
        #endregion
        public IEnumerable<NameValue> GetDoctorTypes()
        {
            List<NameValue> _DoctorTypes = new List<NameValue>();
            try
            {

                var _Reader = DDAM.GETDoctorTypes();
                _DoctorTypes = DB.GetDataObjects<NameValue>(_Reader).ToList();
                return _DoctorTypes;
            }
            catch (Exception ex) { return _DoctorTypes; }
        }
    }
}
