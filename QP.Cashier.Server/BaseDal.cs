using System;
using System.Linq;
using System.Text;
using QP.CashierSystem_Data;
using QP.CashierSystem_Model;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace QP.Cashier.Server
{

    public class BaseDal<T> where T : class, new()
    {

        public  DbContext db = GlobalDBContext.Instance();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="multiple">是否有批量操作</param>
        /// <returns></returns>
        public T AddEntity(T entity, bool multiple = false)
        {
            if (multiple)
            {
                var tran = db.Database.BeginTransaction();
                try
                {
                    db.Set<T>().Add(entity);
                    db.SaveChanges();
                    tran.Commit();
                }
                catch (Exception el)
                {
                    tran.Rollback();
                }
            }
            else
            {
                db.Set<T>().Add(entity);
                db.SaveChangesAsync();
            }

            return entity;
        }
        /// <summary>
        /// 删除的实现
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="multiple">是否批量删除</param>
        /// <returns></returns>
        public bool DeleteEntity(T entity, bool multiple = false)
        {
            if (multiple)
            {

                var tran = db.Database.BeginTransaction();
                try
                {
                    db.Entry<T>(entity).State = EntityState.Deleted;
                    tran.Commit();
                }
                catch (Exception el)
                {
                    tran.Rollback();
                }
            }
            else
            {
                db.Entry<T>(entity).State = EntityState.Deleted;
            }


            return db.SaveChanges() > 0;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Unchanged;
            return db.SaveChanges() > 0;
        }


        /// <summary>
        ///  条件查询【也可以判断是否存在实体】
        /// </summary>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntityies(Expression<Func<T, bool>> whereLamdba)
        {
            //  db.Authoritys.Where<Authoritys>(u => u.AuthorityID > 2);
            return db.Set<T>().Where<T>(whereLamdba);
        }

        public IQueryable<T> LoadPageEntityies<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamdba, Expression<Func<T, s>> orderbyLamdba, bool isAsc)
        {
            //过滤
            var temp = db.Set<T>().Where<T>(whereLamdba);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLamdba).Skip<T>((pageIndex - 1 * pageSize)).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLamdba).Skip<T>((pageIndex - 1 * pageSize)).Take<T>(pageSize);
            }

            return temp;
        }
       
    }
}
