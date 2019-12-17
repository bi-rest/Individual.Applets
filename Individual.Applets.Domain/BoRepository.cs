using Individual.Applets.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Applets.Domain
{
    public abstract class BoRepository<T>  where T : BoEntity
    {

        /// <summary>
        /// EF DbContext
        /// </summary>
        protected AppUnitofWork _unitofWork;
        /// <summary>
        /// 工作单元
        /// </summary>
        public IAppUnitOfWork UnitOfWork { get { return _unitofWork; } }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitofWork"></param>
        public BoRepository(AppUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="bo"></param>
        public void Add(T bo)
        {
            this._unitofWork.Add<T>(bo);
        }
        /// <summary>
        /// 物理删除实体
        /// </summary>
        /// <param name="bo"></param>
        public void Remove(T bo)
        {
            this._unitofWork.Remove<T>(bo);
        }
        /// <summary>
        /// 根据Id查找实体
        /// </summary>
        /// <param name="keyId"></param>
        /// <returns></returns>
        public async ValueTask<T> Find(Guid keyId)
        {
            return await this._unitofWork.Set<T>().FindAsync(keyId);
        }

        public IList<T> FindByCondition(Expression<Func<T, bool>> searchCriteria)
        {
            return this._unitofWork.Set<T>().Where(x => x.KeyId == Guid.NewGuid()).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="searchCriteria"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IList<T> FindByCondition<s>(Expression<Func<T, bool>> searchCriteria, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            if (isAsc)
            {
                return this._unitofWork.Set<T>().Where<T>(searchCriteria).OrderByDescending(orderbyLambda).ToList();
            }
            return this._unitofWork.Set<T>().Where<T>(searchCriteria).OrderBy(orderbyLambda).ToList();
        }

        public (IList<T>, int) FindPagedByCondition<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {

            var temp = this._unitofWork.Set<T>().Where<T>(whereLambda);
            int totalCount = temp.Count();
            if (isAsc)//true升序
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            var data = temp.ToList();
            return (data, totalCount);
        }

        public int CountByCondition(Expression<Func<T, bool>> searchCriteria)
        {
            return this._unitofWork.Set<T>().Where(searchCriteria).Count();
        }

        public int CountAll()
        {
            return this._unitofWork.Set<T>().Count();
        }

        public IList<T> FindAll()
        {
            return this._unitofWork.Set<T>().Where(x => true).ToList();
        }

        public IList<T> FindAll<s>(Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            if (isAsc)
            {
                return this._unitofWork.Set<T>().OrderByDescending(orderbyLambda).ToList();
            }
            return this._unitofWork.Set<T>().OrderBy(orderbyLambda).ToList();
        }

        public IList<T> FindPagedAll<s>(Expression<Func<T, s>> orderbyLambda, bool isAsc, int pageIndex, int pageSize)
        {
            if (isAsc)
            {
                return this._unitofWork.Set<T>().OrderByDescending(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize).ToList();
            }
            return this._unitofWork.Set<T>().OrderBy(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize).ToList();
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="tableName"></param>
        public void BulkInsert(DataTable dataTable, string tableName)
        {
            using (var sqlBulkCopy = new SqlBulkCopy(_unitofWork.GetConn))
            {
                sqlBulkCopy.DestinationTableName = tableName;

                if (dataTable != null && dataTable.Rows.Count != 0)
                {
                    sqlBulkCopy.WriteToServer(dataTable);
                }
                sqlBulkCopy.Close();
            }
        }
        
        public DataTable GetTableSchema(string tableName)
        {
            var data = this._unitofWork.Set<T>().Where<T>(x => x.KeyId == Guid.NewGuid()).ToList();
            return Individual.Applets.Domain.Library.DataTableExtensions.ToDataTable(data);
        }
    }
}
