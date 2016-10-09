using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LXJ.NHibernate.Demo.Model.Auth;
using LXJ.NHibernate.Demo.IDAL.Auth;

namespace LXJ.NHibernate.Demo.DALFactory.Auth
{
    public class DataAccess
    {
        private static readonly string path = "Auth.";

        private DataAccess() { }

        /// <summary>
        /// 创建IUser对象实例
        /// </summary>
        /// <returns></returns>
        public static IUser CreateUser()
        {
            return (IUser)Utility.ReflectServiceLocator.LocateObject("DAL", path + "UserDAL");
        }
    }
}
