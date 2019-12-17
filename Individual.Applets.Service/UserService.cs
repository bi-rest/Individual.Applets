using Individual.Applets.EntityModel;
using Individual.Applets.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Service
{
    public class UserService : BoRepository
    {
        /// <summary>
        /// 用户服务接口
        /// </summary>
        /// <param name="_unitofWork"></param>
        public UserService(AppUnitofWork _unitofWork) : base(_unitofWork) { }

        public void FindAddUser()
        {
            
            base.FindByCondition<User, DateTime>(x => x.IsDelete, x => x.CreateTime, true);
        }
    }
}
