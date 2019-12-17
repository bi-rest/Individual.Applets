using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Individual.Applets.Domain
{
    /// <summary>
    /// 实体抽象基类
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 要求的hashcode
        /// </summary>
        int? _requestedHashCode;
        /// <summary>
        /// Id种子标识
        /// </summary>
        public virtual Guid KeyId { get; set; }

        public Guid GetKeyId()
        {
            return this.KeyId;
        }
        public void SetKeyId(Guid keyid)
        {
            this.KeyId = keyid;
        }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public virtual string CreateUserKeyId { get; private set; }
        /// <summary>
        /// 设置创建人Id
        /// </summary>
        /// <param name="CreateUserKeyId"></param>
        public void SetCreateUserKeyId(string CreateUserKeyId)
        {
            this.CreateUserKeyId = CreateUserKeyId;
        }
        /// <summary>
        /// 创建人名字
        /// </summary>
        public virtual string CreateUserName { get; private set; }

        public void SetCreateUserName(string CreateUserName)
        {
            this.CreateUserName = CreateUserName;
        }


        public virtual string ModifyUserKeyId { get; private set; }
        public void SetModifyUserKeyId(string ModifyUserKeyId)
        {
            this.ModifyUserKeyId = ModifyUserKeyId;
        }

        public virtual string ModifyUserName { get; private set; }
        public void SetModifyUserName(string ModifyUserName)
        {
            this.ModifyUserKeyId = ModifyUserName;
        }

        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 返回创建日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetCreateTime()
        {
            return this.CreateTime;
        }
        /// <summary>
        /// 设置创建日期
        /// </summary>
        /// <param name="createTime"></param>
        public void SetCreateTime(DateTime createTime)
        {
            this.CreateTime = createTime;
        }
        /// <summary>
        /// 返回更新时间
        /// </summary>
        /// <returns></returns>
        public DateTime? GetUpdateTime()
        {
            return this.ModifyTime;
        }
        /// <summary>
        /// 设置更新时间
        /// </summary>
        /// <param name="updateTime"></param>
        public void SetUpdateTime(DateTime updateTime)
        {
            this.ModifyTime = updateTime;
        }



        /// <summary>
        /// 领域事件
        /// </summary>
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
        /// <summary>
        /// 新增领域事件
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        /// <summary>
        /// 删除领域事件
        /// </summary>
        /// <param name="eventItem"></param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        /// <summary>
        /// 明确领域时间
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        /// <summary>
        /// 是暂时的
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return this.KeyId == default(Guid);
        }
        /// <summary>
        /// 比较实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.KeyId == this.KeyId;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.KeyId.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

    }
}
