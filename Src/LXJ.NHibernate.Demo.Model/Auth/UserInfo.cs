using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LXJ.NHibernate.Demo.Model.Auth
{
    public class UserInfo
    {

        public virtual string USER_ID { get; set; }
        public virtual string USER_NAME { get; set; }
        public virtual string PASSWORD { get; set; }


        //注意此处：表明UserInfo与UserProfileInfo为 1:n 
        public virtual IList<UserProfileInfo> UserProfiles { get; set; }

    }//
}//
