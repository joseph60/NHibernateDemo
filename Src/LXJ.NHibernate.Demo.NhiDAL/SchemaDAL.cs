using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

using LXJ.NHibernate.Demo.IDAL;
using LXJ.NHibernate.Demo.Model.Auth;
using DBUtility;

namespace LXJ.NHibernate.Demo.NhiDAL
{
    public class SchemaDAL : ISchema
    {
        public bool Create()
        {
            bool result_stat = false;

            try
            {
                SchemaExport export = new SchemaExport(NHibernateHelper._Configuration);
                export.Create(false, true);
                result_stat = true;
            }
            catch(HibernateException)
            {
                throw;
            }

            return result_stat;
        }

        public bool Drop()
        {
            bool result_stat = false;

            try
            {
                SchemaExport export = new SchemaExport(NHibernateHelper._Configuration);
                export.Drop(false, true);
                result_stat = true;
            }
            catch
            {
            }

            return result_stat;
        }

        public void Init()
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            using (ITransaction trans = session.BeginTransaction())
            {
                try
                {
                    UserInfo user1 = new UserInfo();
                    user1.USER_ID = "User1";
                    user1.USER_NAME = "User Name 1";
                    user1.PASSWORD = "1234";
                    session.Merge(user1);

                    UserInfo user2 = new UserInfo();
                    user2.USER_ID = "User2";
                    user2.USER_NAME = "User Name 2";
                    user2.PASSWORD = "1234";
                    session.Merge(user2);

                    UserProfileInfo user1_p1 = new UserProfileInfo();
                    UserProfilePKInfo user1_p1_pk = new UserProfilePKInfo();
                    user1_p1_pk.USER_ID = "User1";
                    user1_p1_pk.PROFILE_KEY = "ProjectUrl";
                    user1_p1.UserProfilePK = user1_p1_pk;
                    user1_p1.PROFILE_VALUE = "http://openapi.codeplex.com";
                    session.Merge(user1_p1);

                    UserProfileInfo user1_p2 = new UserProfileInfo();
                    UserProfilePKInfo user1_p2_pk = new UserProfilePKInfo();
                    user1_p2_pk.USER_ID = "User1";
                    user1_p2_pk.PROFILE_KEY = "Blog";
                    user1_p2.UserProfilePK = user1_p2_pk;
                    user1_p2.PROFILE_VALUE = "http://liuxiaojun.cnblogs.com";
                    session.Merge(user1_p2);

                    session.Flush();
                    trans.Commit();
                }
                catch(HibernateException)
                {
                    trans.Rollback();
                    throw;
                }
            }
            NHibernateHelper.CloseSession();
        }

    }
}
