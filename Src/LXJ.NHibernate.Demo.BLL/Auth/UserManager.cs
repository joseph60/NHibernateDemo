using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LXJ.NHibernate.Demo.Model.Auth;
using LXJ.NHibernate.Demo.IDAL.Auth;
using LXJ.NHibernate.Demo.DALFactory.Auth;

namespace LXJ.NHibernate.Demo.BLL.Auth
{
    public class UserManager
    {

        private static readonly IUser dal = DataAccess.CreateUser();

        public static bool Exists(string user_id)
        {
            return dal.Exists(user_id);
        }


        public static bool Insert(UserInfo info)
        {
            return dal.Insert(info);
        }

        public static bool Update(UserInfo info)
        {
            return dal.Update(info);
        }

        public static void Delete(string user_id)
        {
            dal.Delete(user_id);
        }

        public static UserInfo GetInfo(string user_id)
        {
            return dal.GetInfo(user_id);
        }

        public static IList<UserInfo> GetList()
        {
            return dal.GetList();
        }

        public static bool Login(string user_id, string password)
        {
            return dal.Login(user_id, password);
        }

    }//
}//
