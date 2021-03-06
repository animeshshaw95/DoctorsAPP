﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.CODE
{
    public static class GlobalConstants
    {
        private static String Conn = ConfigurationManager.AppSettings["DBConn"];
        public static String DBConn = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
        public static Int32 DefaultPageListSize = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPageListSize"]);
        public static string GetConfigVal(string Key)
        {
            string _val = "";
            _val = Convert.ToString(ConfigurationManager.AppSettings[Key]);
            return _val;
        }
    }
}
