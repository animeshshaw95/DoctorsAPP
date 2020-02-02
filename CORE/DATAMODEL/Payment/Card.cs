using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DATAMODEL.Payment
{
    public class Card
    {
        public string HolderName { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public string ExpYear { get; set; }
        public string ExpMonth { get; set; }
    }
}
