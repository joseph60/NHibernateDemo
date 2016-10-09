using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LXJ.NHibernate.Demo.IDAL;
using LXJ.NHibernate.Demo.DALFactory;

namespace LXJ.NHibernate.Demo.BLL
{
    public class SchemaManager
    {

        private static readonly ISchema dal = DataAccess.CreateSchema();

        public static bool Create()
        {
            return dal.Create();
        }


        public static bool Drop()
        {
            return dal.Drop();
        }

        public static void Init()
        {
            dal.Init();
        }

    }
}
