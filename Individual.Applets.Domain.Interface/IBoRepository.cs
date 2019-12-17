using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Individual.Applets.Domain.Interface
{
    /// <summary>
    /// <para>
    /// 本接口是每种领域业务对象的自有仓库接口的泛型定义。不建议在应用层直接使用本泛型接口。建议
    /// 使用业务对象的自有仓库的非泛型接口，或者使用基接口IBaseBoRepository。
    /// </para>
    /// </summary>
    /// <typeparam name="IBoT">需要管理的业务对象接口</typeparam>
    /// <typeparam name="SearchCriteriaT">所使用的搜索条件类</typeparam>
    /// <typeparam name="SortCriteriaT">所使用的排序条件类</typeparam>
    public interface IBoRepository<IBoT> where IBoT : IAggregateRoot
    {

        IAppUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 把一个新建的业务对象交给Repository管理
        /// </summary>
        /// <param name="item">新建的业务对象</param>
        void Add(IBoT bo);

        /// <summary>
        /// 把指定的业务对象从repository中删除
        /// </summary>
        /// <param name="item">需要被删除的业务对象</param>
        void Remove(IBoT bo);

        /// <summary>
        /// 根据keyId寻找业务对象
        /// </summary>
        /// <returns>KeyId所对应的业务对象，或者NULL</returns>
        ValueTask<IBoT> Find(Guid keyId);

        /// <summary>
        /// 根据给定的搜索条件寻找业务对象
        /// </summary>
        /// <param name="SearchCriteria">搜索条件</param>
        /// <returns>业务对象列表</returns>
        IList<IBoT> FindByCondition(System.Linq.Expressions.Expression<Func<IBoT, bool>> searchCriteria);

        /// <summary>
        /// 根据给定的搜索条件寻找业务对象，返回列表按照给定的方式排序
        /// </summary>
        /// <param name="searchCriteria">搜索条件</param>
        /// <param name="sortCriteria">排序方式</param>
        /// <returns></returns>
        IList<IBoT> FindByCondition<s>(System.Linq.Expressions.Expression<Func<IBoT, bool>> searchCriteria, Expression<Func<IBoT, s>> orderbyLambda, bool isAsc);

        /// <summary>
        /// 根据给定的搜索条件寻找业务对象，支持Paging功能和非Paging功能
        /// </summary>
        /// <param name="searchCriteria">搜索条件</param>
        /// <param name="sortCriteria">排序方式</param>
        /// <param name="pageIndex">页码号，从1开始</param>
        /// <param name="pageSize">每页的对象个数</param>
        /// <returns></returns>
        (IList<IBoT>, int) FindPagedByCondition<s>(int pageIndex, int pageSize, Expression<Func<IBoT, bool>> whereLambda, Expression<Func<IBoT, s>> orderbyLambda, bool isAsc);

        /// <summary>
        /// 返回满足搜寻条件的业务对象的数目
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        int CountByCondition(Expression<Func<IBoT, bool>> searchCriteria);

        /// <summary>
        /// 返回所有业务对象的数目 
        /// </summary>
        /// <returns></returns>
        int CountAll();

        /// <summary>
        /// 寻找所有业务对象
        /// </summary>
        /// <returns></returns>
        IList<IBoT> FindAll();

        /// <summary>
        /// 寻找所有业务对象，返回列表按照给定的方式排序
        /// </summary>
        /// <param name="sortCriteria">排序方式</param>
        /// <returns></returns>
        IList<IBoT> FindAll<s>(Expression<Func<IBoT, s>> orderbyLambda, bool isAsc);

        /// <summary>
        /// 寻找所有业务对象，支持Paging功能
        /// </summary>
        /// <param name="sortCriteria">排序方式</param>
        /// <param name="pageIndex">页码号，从1开始</param>
        /// <param name="pageSize">每页的对象个数</param>
        /// <returns></returns>
        IList<IBoT> FindPagedAll<s>(Expression<Func<IBoT, s>> orderbyLambda, bool isAsc, int pageIndex, int pageSize);
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="tableName">表名称</param>
        void BulkInsert(DataTable dt, string tableName);
        /// <summary>
        /// 根据表明得到架构图
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataTable GetTableSchema(string tableName);
    }
}
