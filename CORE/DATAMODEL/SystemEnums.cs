using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DATAMODEL
{
    public enum UserTypes:int
    {
        Admin=1001,
        Doctor=2001
    }
    public enum Mode:int
    {
        Insert=1,
        Update=2
    }
}
