using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DATAMODEL.Payment
{
    public class AuthoriseRequest
    {
        public Card card { get; set; }
        public string email { get; set; }
        public string merchantID { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public object metadata { get; set; }
        public bool allow3Ds { get; set; }
    }
}
