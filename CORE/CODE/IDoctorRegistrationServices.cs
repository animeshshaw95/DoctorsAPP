using CORE.DATAMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CODE
{
    public interface IDoctorRegistrationServices
    {
        IEnumerable<NameValue> GetDoctorTypes();
    }
}
