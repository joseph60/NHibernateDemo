using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LXJ.NHibernate.Demo.Model.Auth
{
    public class UserProfileInfo
    {
        //把组合主键（USER_ID,PROFILE_KEY）抽象成一个类UserProfilePKInfo
        public virtual UserProfilePKInfo UserProfilePK { get; set; }


        public virtual string PROFILE_VALUE { get; set; }

    }
}
