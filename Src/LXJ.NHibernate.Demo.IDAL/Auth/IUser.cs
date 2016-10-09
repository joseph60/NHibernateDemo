using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LXJ.NHibernate.Demo.Model.Auth;

namespace LXJ.NHibernate.Demo.IDAL.Auth
{
    public interface IUser
    {
        bool Exists(string user_id);
        bool Insert(UserInfo info);
        bool Update(UserInfo info);
        void Delete(string user_id);

        UserInfo GetInfo(string user_id);
        IList<UserInfo> GetList();

        bool Login(string user_id, string password);
    }
}
