using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CODE
{
    public interface IGlobal
    {
        String ConnectionString();
        Int32 DefaultPageListSize();
    }
}
