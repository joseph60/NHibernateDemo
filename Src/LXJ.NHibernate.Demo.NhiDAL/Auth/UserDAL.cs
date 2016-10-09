using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Linq;

using LXJ.NHibernate.Demo.Model.Auth;
using LXJ.NHibernate.Demo.IDAL.Auth;
using DBUtility;

namespace LXJ.NHibernate.Demo.NhiDAL.Auth
{
    public class UserDAL : IUser
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public bool Exists(string user_id)
        {
            bool result_stat = false;
            ISession session = NHibernateHelper.GetCurrentSession();

            var user = session.Query<UserInfo>().SingleOrDefault(u => u.USER_ID == user_id);
            if (user != null)
            {
                result_stat = true;
            }
            NHibernateHelper.CloseSession();

            return result_stat;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(UserInfo info)
        {
            bool result_stat = false;

            ISession session = NHibernateHelper.GetCurrentSession();

            UserInfo exists_user = session.Query<UserInfo>().SingleOrDefault(u => u.USER_ID == info.USER_ID);
            if (exists_user == null)
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(info);
                        session.Flush();
                        trans.Commit();

                        result_stat = true;
                    }
                    catch (HibernateException)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            NHibernateHelper.CloseSession();

            return result_stat;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(UserInfo info)
        {
            bool result_stat = false;

            ISession session = NHibernateHelper.GetCurrentSession();
            UserInfo exists_user = session.Query<UserInfo>().SingleOrDefault(u => u.USER_ID == info.USER_ID);
            if (exists_user != null)
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    try
                    {
                        exists_user.USER_NAME = info.USER_NAME;

                        session.Update(exists_user);
                        session.Flush();
                        trans.Commit();

                        result_stat = true;
                    }
                    catch (HibernateException)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            NHibernateHelper.CloseSession();

            return result_stat;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="user_id"></param>
        public void Delete(string user_id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            UserInfo exists_user = session.Query<UserInfo>().SingleOrDefault(u => u.USER_ID == user_id);
            if (exists_user != null)
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(exists_user);

                        //批量删除Profiles
                        session.Delete(" from UserProfileInfo p where p.UserProfilePK.USER_ID = ? ", user_id, NHibernateUtil.String);

                        session.Flush();
                        trans.Commit();
                    }
                    catch (HibernateException)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            NHibernateHelper.CloseSession();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public UserInfo GetInfo(string user_id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            UserInfo exists_user = session.Query<UserInfo>().SingleOrDefault(u => u.USER_ID == user_id);
            NHibernateHelper.CloseSession();

            return exists_user;
        }

        /// <summary>
        /// GetList
        /// </summary>
        /// <returns></returns>
        public IList<UserInfo> GetList()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            IList<UserInfo> users = session.Query<UserInfo>().ToList();
            NHibernateHelper.CloseSession();

            return users;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string user_id, string password)
        {
            bool result_stat = false;

            ISession session = NHibernateHelper.GetCurrentSession();
            UserInfo exists_user = session.Query<UserInfo>().SingleOrDefault(u => u.USER_ID == user_id && u.PASSWORD == password);
            if (exists_user == null)
            {
                result_stat = true;
            }
            NHibernateHelper.CloseSession();

            return result_stat;
        }

    }//
}//
