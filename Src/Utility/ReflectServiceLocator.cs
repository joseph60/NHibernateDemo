using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Reflection;

namespace Utility
{
    public static class ReflectServiceLocator
    {

        public static Assembly LoadAssembly(string assemblyConfigKey)
        {
            string assemblyConfigValue = ConfigurationManager.AppSettings[assemblyConfigKey].ToString();

            return Assembly.Load(assemblyConfigValue);
        }

        public static object LocateObject(string assemblyConfigKey, string className)
        {
            string assemblyConfigValue = ConfigurationManager.AppSettings[assemblyConfigKey].ToString();

            Assembly assembly = LoadAssembly(assemblyConfigKey);
            return assembly.CreateInstance(assemblyConfigValue + "." + className);
        }

    }
}
