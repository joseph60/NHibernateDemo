using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.IO;

using NHibernate;
using NHibernate.Cfg;

namespace DBUtility
{
    public abstract class NHibernateHelper 
    {
        public static readonly string _XmlConfigFilePath = (System.Configuration.ConfigurationManager.AppSettings["XmlConfigurationFilePath"] == null) ? "" : System.Configuration.ConfigurationManager.AppSettings["XmlConfigurationFilePath"].ToString();
        private static readonly bool _FromConfig = false;

        public static readonly Configuration _Configuration;
        private const string _CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _SessionFactory;

        [ThreadStatic]//声明为线程共享
        public static ISession sessionWin;//winform程序使用


        static NHibernateHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
            _Configuration = new Configuration();

            //判断是否有单独的配置文件，如果有，则以配置文件为准；反之，以web.config为准
            //注意：一定要为实际物理地址
            if (!string.IsNullOrEmpty(_XmlConfigFilePath) && File.Exists(_XmlConfigFilePath))
            {
                //有
                _SessionFactory = _Configuration.Configure(_XmlConfigFilePath).BuildSessionFactory();
                _FromConfig = false;
            }
            else
            {
                //无
                _SessionFactory = _Configuration.Configure().BuildSessionFactory();
                _FromConfig = true;
            }
        }

        public static ISession GetCurrentSession()
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                //webform程序使用
                ISession currentSession = context.Items[_CurrentSessionKey] as ISession;
                if (currentSession == null)
                {
                    currentSession = _SessionFactory.OpenSession();
                    context.Items[_CurrentSessionKey] = currentSession;
                }
                else
                {
                    if (!currentSession.IsConnected)
                    {
                        currentSession = _SessionFactory.OpenSession();
                    }
                }

                return currentSession;
            }
            else
            {
                //winform程序使用
                if (sessionWin.Equals(null))
                {
                    sessionWin = _SessionFactory.OpenSession();
                }

                return sessionWin;
            }
        }

        public static ISession GetCurrentSession(string configFilePath)
        {
            //是否和默认配置文件一样
            if ((_XmlConfigFilePath == configFilePath) || (_FromConfig))
            {
                return GetCurrentSession();
            }
            else
            {
                HttpContext context = HttpContext.Current;
                if (context != null)
                {
                    //webform程序使用
                    ISession currentSession = context.Items[configFilePath] as ISession;
                    if (currentSession == null)
                    {
                        currentSession = new Configuration().Configure(configFilePath).BuildSessionFactory().OpenSession();
                        context.Items[configFilePath] = currentSession;
                    }
                    else
                    {
                        if (!currentSession.IsConnected)
                        {
                            currentSession = _SessionFactory.OpenSession();
                        }
                    }

                    return currentSession;
                }
                else
                {
                    //winform程序使用
                    if (sessionWin.Equals(null))
                    {
                        sessionWin = new Configuration().Configure(configFilePath).BuildSessionFactory().OpenSession();
                    }

                    return sessionWin;
                }
            }
        }


        public static void CloseSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[_CurrentSessionKey] as ISession;
            if (currentSession == null)
            {
                // No current session                
                return;
            }
            currentSession.Close();
            context.Items.Remove(_CurrentSessionKey);
        }

        public static void CloseSession(string configFilePath)
        {
            if ((_XmlConfigFilePath == configFilePath) || (_FromConfig))
            {
                CloseSession();
            }
            else
            {
                HttpContext context = HttpContext.Current;
                ISession currentSession = context.Items[configFilePath] as ISession;
                if (currentSession == null)
                {
                    // No current session                
                    return;
                }
                currentSession.Close();
                context.Items.Remove(configFilePath);
            }
        }


        public static void CloseSessionFactory()
        {
            if (_SessionFactory != null)
            {
                _SessionFactory.Close();
            }
        }

    }//
}//
