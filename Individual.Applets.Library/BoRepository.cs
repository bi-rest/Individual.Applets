using Individual.Applets.EntityModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Applets.Library
{
    /// <summary>
    /// 仓储基类层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BoRepository//<T> where T : BoKeyId
    {

        /// <summary>
        /// EF DbContext
        /// </summary>
        protected AppUnitofWork _unitofWork;

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
        public void Add<T>(T bo) where T : BoKeyId
        {
            this._unitofWork.Add<T>(bo);
        }
        /// <summary>
        /// 物理删除实体
        /// </summary>
        /// <param name="bo"></param>
        public void Remove<T>(T bo) where T : BoKeyId
        {
            this._unitofWork.Remove<T>(bo);
        }
        /// <summary>
        /// 根据Id查找实体
        /// </summary>
        /// <param name="keyId"></param>
        /// <returns></returns>
        public async ValueTask<T> Find<T>(Guid keyId) where T : BoKeyId
        {
            return await this._unitofWork.Set<T>().FindAsync(keyId);
        }

        public IList<T> FindByCondition<T>(Expression<Func<T, bool>> searchCriteria) where T : BoKeyId
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
        public IList<T> FindByCondition<T, s>(Expression<Func<T, bool>> searchCriteria, Expression<Func<T, s>> orderbyLambda, bool isAsc) where T : BoKeyId
        {
            if (isAsc)
            {
                return this._unitofWork.Set<T>().Where<T>(searchCriteria).OrderByDescending(orderbyLambda).ToList();
            }
            return this._unitofWork.Set<T>().Where<T>(searchCriteria).OrderBy(orderbyLambda).ToList();
        }

        public (IList<T>, int) FindPagedByCondition<T, s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc) where T : BoKeyId
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

        public int CountByCondition<T>(Expression<Func<T, bool>> searchCriteria) where T : BoKeyId
        {
            return this._unitofWork.Set<T>().Where(searchCriteria).Count();
        }

        public int CountAll<T>() where T : BoKeyId
        {
            return this._unitofWork.Set<T>().Count();
        }

        public IList<T> FindAll<T>() where T : BoKeyId
        {
            return this._unitofWork.Set<T>().Where(x => true).ToList();
        }

        public IList<T> FindAll<T, s>(Expression<Func<T, s>> orderbyLambda, bool isAsc) where T : BoKeyId
        {
            if (isAsc)
            {
                return this._unitofWork.Set<T>().OrderByDescending(orderbyLambda).ToList();
            }
            return this._unitofWork.Set<T>().OrderBy(orderbyLambda).ToList();
        }

        public IList<T> FindPagedAll<T, s>(Expression<Func<T, s>> orderbyLambda, bool isAsc, int pageIndex, int pageSize) where T : BoKeyId
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
            using (var sqlBulkCopy = new SqlBulkCopy(_unitofWork._databaseConn))
            {
                sqlBulkCopy.DestinationTableName = tableName;

                if (dataTable != null && dataTable.Rows.Count != 0)
                {
                    sqlBulkCopy.WriteToServer(dataTable);
                }
                sqlBulkCopy.Close();
            }
        }

        public DataTable GetTableSchema<T>(string tableName) where T : BoKeyId
        {
            var data = this._unitofWork.Set<T>().Where<T>(x => x.KeyId == Guid.NewGuid()).ToList();
            return DataTableExtensions.ToDataTable(data);
        }

    }
}
