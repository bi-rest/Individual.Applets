using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.ViewModel
{
    /// <summary>
    /// 接受api参数实体基类
    /// </summary>
    public abstract class BaseReceive
    {
        /// <summary>
        /// 请求权限token
        /// </summary>
        public string _token { get; set; }
        /// <summary>
        /// 用户code
        /// </summary>
        public string code { get; set; }

    }
}
