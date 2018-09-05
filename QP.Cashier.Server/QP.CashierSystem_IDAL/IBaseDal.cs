using System;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace QP.Cashier.Server.QP.CashierSystem_IDAL
{
    /// <summary>
    ///  实体操作接口
    /// </summary>
    public interface IBaseDal<T> where T : class, new()
    {
        /// <summary>
        /// 条件过滤
        /// </summary>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntityies(Expression<Func<T, bool>> whereLamdba);
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s">各种数据类型</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="totalCount">行数</param>
        /// <param name="whereLamdba">排序条件</param>
        /// <param name="orderbyLamdba"></param>
        /// <param name="isAsc">true:正排序,false:倒排序</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntityies<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamdba, Expression<Func<T, s>> orderbyLamdba, bool isAsc);
        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity,bool multiple=false);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool EditEntity(T entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity, bool multiple = false);
     
    }

}
