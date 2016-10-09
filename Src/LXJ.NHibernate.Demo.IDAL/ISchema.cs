using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LXJ.NHibernate.Demo.IDAL
{
    public interface ISchema
    {
        bool Create();
        bool Drop();
        void Init();
    }
}
