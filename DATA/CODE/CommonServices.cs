using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CODE;
using CORE.DATAMODEL.Common;
using DATA.DATACONNECTION;
using DATA.DBACCESSMODEL;

namespace DATA.CODE
{
    public class CommonServices:ICommonServices
    {
        #region Global Variable
        private readonly DataConnection DB;
        private readonly CommonDBAccessModel CDAM;
        #endregion

        #region CTOR
        public CommonServices(IGlobal global)
        {
            DB = new DataConnection();
            CDAM = new CommonDBAccessModel(global);
        }
        #endregion

        public IEnumerable<City> GetCities(string StateCode)
        {
            List<City> cities = new List<City>();
            try
            {
                var reader = CDAM.GETCities(StateCode);
                cities = DB.GetDataObjects<City>(reader).ToList();
            }
            catch (Exception ex)
            {

            }
            return cities;
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            try
            {
                var reader = CDAM.GETSpecializations();
                specializations = DB.GetDataObjects<Specialization>(reader).ToList();
            }
            catch (Exception ex)
            {

            }
            return specializations;
        }

        public IEnumerable<State> GetStates()
        {
            List<State> states = new List<State>();
            try
            {
                var reader = CDAM.GETStates();
                states = DB.GetDataObjects<State>(reader).ToList();
            }
            catch (Exception ex)
            {

            }
            return states;
        }
    }
}
