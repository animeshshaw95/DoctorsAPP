using CORE.CODE;
using CORE.CODE.Registration.Doctor;
using CORE.DATAMODEL.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorsApp.Controllers
{
    public class RegisterController : Controller
    {
        #region Global Variables
        ICommonServices _commonServices;
        IDoctorServices _doctorServices;
        #endregion

        #region CTOR
        public RegisterController(ICommonServices commonServices,IDoctorServices doctorServices)
        {
            _commonServices = commonServices;
            _doctorServices = doctorServices;
        }
        #endregion

        // GET: Register
        public ActionResult Index()
        {
            DoctorRegistration doctorRegistration = new DoctorRegistration();
            doctorRegistration.states = _commonServices.GetStates().ToList();
            doctorRegistration.specializations = _commonServices.GetSpecializations().ToList();
            doctorRegistration.cities = new List<CORE.DATAMODEL.Common.City>();
            return View(doctorRegistration);
        }

        [HttpPost]
        public ActionResult Index(DoctorRegistration req)
        {
            if (!ModelState.IsValid)
            {
                req.states = _commonServices.GetStates().ToList();
                req.specializations = _commonServices.GetSpecializations().ToList();
                req.cities = _commonServices.GetCities(req.State).ToList();
                return View(req);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard",new { });
            }
        }

       
        [HttpGet]
        public JsonResult GetCities(string StateCode)
        {
            List<CORE.DATAMODEL.Common.City> cities = new List<CORE.DATAMODEL.Common.City>();
            try
            {
                cities = _commonServices.GetCities(StateCode).ToList();
            }
            catch(Exception ex) { }
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}