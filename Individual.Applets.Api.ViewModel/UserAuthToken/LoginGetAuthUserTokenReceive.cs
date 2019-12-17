using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.ViewModel.UserAuthToken
{
    /// <summary>
    /// 登录或者注册用户，返回token值
    /// </summary>
    public class LoginGetAuthUserTokenReceive : BaseReceive
    {
        /// <summary>
        /// 微信名称
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string avatarUrl { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }

    }
}
