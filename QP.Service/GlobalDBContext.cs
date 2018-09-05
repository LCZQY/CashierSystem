using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QP.Cashier_Data;

namespace QP.Cashier_Service
{
    /// <summary>
    ///  负责创建EF数据操作上下文实例，单例模式，确保一个类只有一个实例,并提供一个全局访问点
    /// </summary>
    public class GlobalDBContext
    {
        ///定义一个标识确保线程同步
        public static readonly object locker = new object();

        // 静态变量来保护类的实例
        private static CollectMoneyContext _db = null;
        /// <summary>
        /// 定义私有构造函数，使外界不能创建该类实例
        /// </summary>
        private GlobalDBContext() { }

        public static CollectMoneyContext Instance()
        {  
            //为了减少不必要的开销
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"         
            if (_db == null)
            {
                lock (locker)
                {
                    if (null == _db)
                    {
                        _db = new CollectMoneyContext();                        
                    }
                }
            }
            return _db;
        }
    }
}
