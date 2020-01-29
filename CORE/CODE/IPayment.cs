using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CODE
{
    public interface IPayment
    {
        void Capture();
        bool ApplyTo(string className);
    }
}
