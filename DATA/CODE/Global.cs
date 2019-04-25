using CORE.CODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE
{
    public class Global:IGlobal
    {
        private readonly String _connectionstring;
        private readonly Int32 _defaultpagelistsize;
        public Global(String connectionstring, Int32 defaultpagelistsize)
        {
            _connectionstring = connectionstring;
            _defaultpagelistsize = defaultpagelistsize;
        }
        public String ConnectionString()
        {
            return _connectionstring;
        }
        public Int32 DefaultPageListSize()
        {
            return _defaultpagelistsize;
        }
    }
}
