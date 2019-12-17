using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Domain
{
    /// <summary>
    /// 领域异常控制器
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException()
        { }

        public DomainException(string message)
            : base(message)
        { }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
