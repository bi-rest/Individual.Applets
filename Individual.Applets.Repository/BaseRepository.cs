using Individual.Applets.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Applets.Repository
{
    public class BaseRepository<T> where T : Entity
    {
        /// <summary>
        /// EF DbContext
        /// </summary>
        protected AppUnitofWork _unitofWork;
        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork { get { return _unitofWork; } }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitofWork"></param>
        public BaseRepository(AppUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public T Add(T user)
        {
            if (user.IsTransient())
            {
                return _unitofWork.Set<T>().Add(user).Entity;
            }
            return user;
        }
        /// <summary>
        /// 根据用户Id用户信息
        /// </summary>
        /// <param name="KeyId"></param>
        /// <returns></returns>
        public T Get(Guid KeyId)
        {
            var user = _unitofWork.Set<T>().FirstOrDefault(x => x.KeyId == KeyId);
            return user;
        }
        /// <summary>
        /// 根据用户Id用户信息 异步
        /// </summary>
        /// <param name="KeyId"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(Guid KeyId)
        {
            var model = await _unitofWork.Set<T>().FindAsync(KeyId);
            return model;
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="user"></param>
        public void Update(T user)
        {
            _unitofWork.Entry(user).State = EntityState.Modified;
        }

    }
}
