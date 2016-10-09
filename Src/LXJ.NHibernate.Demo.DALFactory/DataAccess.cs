using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LXJ.NHibernate.Demo.IDAL;

namespace LXJ.NHibernate.Demo.DALFactory
{
    public class DataAccess
    {
        private static readonly string path = "";

        private DataAccess() { }

        /// <summary>
        /// 创建ISchema对象实例
        /// </summary>
        /// <returns></returns>
        public static ISchema CreateSchema()
        {
            return (ISchema)Utility.ReflectServiceLocator.LocateObject("SchemaDAL", path + "SchemaDAL");
        }
    }
}
