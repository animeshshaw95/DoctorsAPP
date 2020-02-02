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
        private readonly Dictionary<string, string> _globalConfig;
        public Global(String connectionstring, Int32 defaultpagelistsize,Dictionary<string,string> globalConfig)
        {
            _connectionstring = connectionstring;
            _defaultpagelistsize = defaultpagelistsize;
            _globalConfig = globalConfig;
        }
        public String ConnectionString()
        {
            return _connectionstring;
        }
        public Int32 DefaultPageListSize()
        {
            return _defaultpagelistsize;
        }
        public Dictionary<string, string> GetAllConfigs()
        {
            return _globalConfig;
        }
    }
}
