using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CODE
{
    public interface IPaymentStrategy
    {
        IPayment GetPayment(string className);
    }
}
