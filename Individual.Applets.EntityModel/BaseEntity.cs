using System;
using System.ComponentModel.DataAnnotations;

namespace Individual.Applets.EntityModel
{
    /// <summary>
    /// 实体所继承的抽象类
    /// </summary>
    public abstract class BaseEntity : BoKeyId
    {

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 是否被删除
        /// false 为未删除，true为正常
        /// </summary>
        [DataType("int")]
        public bool IsDelete { get; set; } = false;
        /// <summary>
        /// 是否启用
        /// false 为未停用，true为正常
        /// </summary>
        [DataType("int")]
        public bool IsFalg { get; set; } = true;
    }
}
