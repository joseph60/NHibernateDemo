using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LXJ.NHibernate.Demo.Model.Auth
{
    public class UserProfilePKInfo
    {
        public virtual string USER_ID { get; set; }
        public virtual string PROFILE_KEY { get; set; }


        /// <summary>
        /// 判断两个对象是否相同，这个方法需要重写
        /// </summary>
        /// <param name="obj">进行比较的对象</param>
        /// <returns>真true或假false</returns>
        public override bool Equals(object obj)
        {
            if (obj is UserProfilePKInfo)
            {
                UserProfilePKInfo pk = obj as UserProfilePKInfo;
                if (this.USER_ID == pk.USER_ID
                     && this.PROFILE_KEY == pk.PROFILE_KEY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
