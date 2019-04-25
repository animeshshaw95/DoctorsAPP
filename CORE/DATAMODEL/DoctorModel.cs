using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CORE.DATAMODEL
{
    public class DoctorInsertModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public int[] DoctorTypes { get; set; }
        public List<NameValue> DoctorTypeList { get; set; }
    }
    public class DoctorUpdateModel:DoctorInsertModel
    {
        public string ID { get; set; }
    }
}
