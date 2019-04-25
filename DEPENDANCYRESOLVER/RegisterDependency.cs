using CORE.CODE;
using DATA.CODE;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPENDANCYRESOLVER
{
    public class RegisterDependency
    {
        public static void RegisterDependencies(IKernel kernel, String dbconn, Int32 defaultpagelistsize)
        {
            String DBConn = dbconn;
            kernel.Bind<IGlobal>()
                     .To<Global>()
                     .WithConstructorArgument("connectionstring", DBConn)
                     .WithConstructorArgument("defaultpagelistsize", defaultpagelistsize);

            kernel.Bind<IDoctorRegistrationServices>()
                     .To<DoctorRegistrationServices>().InSingletonScope();

        }
    }
}
