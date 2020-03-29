using CORE.DATAMODEL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CODE
{
    public interface ICommonServices
    {
        IEnumerable<State> GetStates();
        IEnumerable<City> GetCities(string StateCode);
        IEnumerable<Specialization> GetSpecializations();
    }
}
