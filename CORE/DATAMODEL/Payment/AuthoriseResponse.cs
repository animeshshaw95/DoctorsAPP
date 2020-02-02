using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DATAMODEL.Payment
{
    public class AuthoriseResponse
    {
        public string transactionID { get; set; }
        public bool Is3DS { get; set; }
        public string issuerURL { get; set; }
        public object payloads { get; set; }
    }
}
