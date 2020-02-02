using CORE.CODE;
using CORE.DATAMODEL.Payment;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE
{
    public class StripePayment : IPayment
    {
        private readonly IGlobal _global;
        public StripePayment(IGlobal global)
        {
            _global = global;
            if (_global.GetAllConfigs().FirstOrDefault(x => x.Key == "StripeMode").Value.ToLower() == "test")
                StripeConfiguration.ApiKey = _global.GetAllConfigs().FirstOrDefault(x => x.Key == "StripeSecretKeyTest").Value;
            else
                StripeConfiguration.ApiKey = _global.GetAllConfigs().FirstOrDefault(x => x.Key == "StripeSecretKeyProduction").Value;
        }
        public bool ApplyTo(string className)
        {
            return this.GetType().Name.ToLower().Contains(className.ToLower());
        }

        public AuthoriseResponse Authorise(AuthoriseRequest request)
        {
            AuthoriseResponse response = new AuthoriseResponse();
            var options = new PaymentIntentCreateOptions
            {
                Amount = Convert.ToInt64(request.amount*100),
                Currency = request.currency,
                PaymentMethodTypes = new List<string>
                  {
                    "card",
                  },
                CaptureMethod="manual",
                //Metadata = request.metadata as Dictionary<string, string>,
                
            };
            var service = new PaymentIntentService();
            service.Create(options);
            return response;
        }

        public void Capture()
        {

        }
    }
}
