using CORE.CODE;
using CORE.DATAMODEL.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE
{
    public class AdyenPayment:IPayment
    {
        public bool ApplyTo(string className)
        {
            return this.GetType().Name.ToLower().Contains(className.ToLower());
        }

        public AuthoriseResponse Authorise(AuthoriseRequest request)
        {
            throw new NotImplementedException();
        }

        public void Capture()
        {

        }
    }
}
