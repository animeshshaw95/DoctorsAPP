using CORE.CODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE
{
    public class PaymentStrategy : IPaymentStrategy
    {
        IPayment[] payments;
        public PaymentStrategy(IPayment[] payments)
        {
            this.payments = payments;
        }
        public IPayment GetPayment(string className)
        {
            return payments.FirstOrDefault(x => x.ApplyTo(className));
        }
    }
}
