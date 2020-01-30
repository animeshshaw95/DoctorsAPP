using CORE.CODE;
using CORE.DATAMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorsApp.Controllers
{
    public class DoctorController : Controller
    {
        #region Global Variable
        private readonly IDoctorRegistrationServices _RS;
        #endregion
        #region CTOR
        public DoctorController(IDoctorRegistrationServices RS)
        {
            _RS = RS;
        }
        #endregion
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateDoctorProfile()
        {
            DoctorInsertModel model = new DoctorInsertModel();
            model.DoctorTypeList = _RS.GetDoctorTypes().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateDoctorProfile(DoctorInsertModel model,HttpPostedFileBase File)
        {
            model.DoctorTypeList = _RS.GetDoctorTypes().ToList();
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Verification failed";
                TempData["IsError"] = "true";
            }

            TempData["Message"] = "Verification failed";
            TempData["IsError"] = "true";
            return View(model);
        }

    }
}