using CORE.DATAMODEL.Common;
using CORE.DATAMODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DATAMODEL.Doctor
{
    public class DoctorRegistration
    {
        [Required(ErrorMessage ="First name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email address required")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [DisplayName("Mobile number")]
        public string MobileNumber { get; set; }
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "DOB is required")]
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }
        [MinLength(1,ErrorMessage = "Specialization is required")]
        [DisplayName("Specialization")]
        public long[] SpecialistIn { get; set; }
        [Required(ErrorMessage = "State is required")]
        [DisplayName("State")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is required")]
        [DisplayName("City")]
        public string City { get; set; }
        public List<City> cities { get; set; }
        public List<State> states { get; set; }
        public List<Specialization> specializations { get; set; }
    }
    public class DoctorUpdate:DoctorRegistration
    {
        public long ID { get; set; }
    }
}
