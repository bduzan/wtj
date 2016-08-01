using System;
using System.Configuration;

namespace WillingToJoin.Shared.Utils
{
    public class ConfigUtil
    {
        public static bool IsDevelopment()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["IsDevelopment"]);
        }
    }
}
