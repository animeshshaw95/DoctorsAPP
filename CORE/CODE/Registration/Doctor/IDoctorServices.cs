using CORE.DATAMODEL.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CODE.Registration.Doctor
{
    public interface IDoctorServices
    {
        DoctorRegistrationResponse RegisterDoctor(DoctorRegistration Req);
    }
}
