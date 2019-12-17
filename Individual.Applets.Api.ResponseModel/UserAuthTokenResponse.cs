using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Api.ResponseModel
{
    /// <summary>
    /// 返回密钥实体模型
    /// </summary>
    public class UserAuthTokenResponse
    {
        /// <summary>
        /// 授权token
        /// </summary>
        public string _TokenKey { get; set; }

        /// <summary>
        /// token有效期
        /// </summary>
        public DateTime ExpiredTime { get; set; }

    }
}
