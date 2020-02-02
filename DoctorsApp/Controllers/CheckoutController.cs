using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CORE.CODE;
using CORE.DATAMODEL;
using CORE.DATAMODEL.Payment;

namespace DoctorsApp.Controllers
{
    public class CheckoutController : Controller
    {
        #region Global Variable
        private readonly IPaymentStrategy _payments;
        private readonly IGlobal _global;
        #endregion
        #region CTOR
        public CheckoutController(IPaymentStrategy payments, IGlobal global)
        {
            _payments = payments;
            _global = global;
        }
        #endregion
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Confirm()
        {
            IPayment payment = _payments.GetPayment(_global.GetAllConfigs().FirstOrDefault(x=>x.Key== "PaymentClass").Value);
            AuthoriseRequest authoriseRequest = new AuthoriseRequest()
            {
                
            };
            var response=payment.Authorise(authoriseRequest);

            return View();
        }
    }
}