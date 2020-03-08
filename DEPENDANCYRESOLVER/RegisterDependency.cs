using CORE.CODE;
using CORE.CODE.Registration.Doctor;
using DATA.CODE;
using DATA.CODE.Registration.Doctor;
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
        public static void RegisterDependencies(IKernel kernel, String dbconn, Int32 defaultpagelistsize, Dictionary<string,string> allConfigs)
        {
            String DBConn = dbconn;
            kernel.Bind<IGlobal>()
                     .To<Global>()
                     .WithConstructorArgument("connectionstring", DBConn)
                     .WithConstructorArgument("defaultpagelistsize", defaultpagelistsize)
                     .WithConstructorArgument("globalConfig", allConfigs);

            kernel.Bind<IDoctorRegistrationServices>()
                     .To<DoctorRegistrationServices>().InSingletonScope();
            kernel.Bind<IPayment>()
                     .To<StripePayment>().InSingletonScope();
            kernel.Bind<IPayment>()
                     .To<AdyenPayment>().InSingletonScope();
            kernel.Bind<IPaymentStrategy>()
                     .To<PaymentStrategy>().WithConstructorArgument("payments", kernel.GetAll<IPayment>().ToArray());
            kernel.Bind<IDoctorServices>()
                     .To<DoctorServices>().InSingletonScope();

        }
    }
}
