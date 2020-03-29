using CORE.CODE;
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
        #endregion

        #region CTOR
        public RegisterController(ICommonServices commonServices)
        {
            _commonServices = commonServices;
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
            req.states = _commonServices.GetStates().ToList();
            req.specializations = _commonServices.GetSpecializations().ToList();
            req.cities = req.cities;
            return View(req);
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