using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individual.Applets.EntityModel
{
    public abstract class BoKeyId
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        public Guid KeyId { get; set; }
    }
}
