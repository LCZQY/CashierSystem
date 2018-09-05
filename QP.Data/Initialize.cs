
using QP.Cashier_Model.CreateEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QP.Cashier_Data
{
    /// <summary>
    /// 实例化数据库
    /// </summary>
    public class Initialize
    {
        public Initialize()
        {
            using (var db = new CollectMoneyContext())
            {
                //直接创建数据库
                db.Database.EnsureCreated();
                var authon = new Authoritys[] {
                     //一般管理员
                     new Authoritys{ Roleds="admin", AuthorityName="一般管理员", AuthorityID="adm" },
                     new Authoritys{ Roleds="adm", AuthorityName="店长", AuthorityID="stroe" },
                     new Authoritys{ Roleds="adm", AuthorityName="地区经理", AuthorityID="manager" },
                     new Authoritys{ Roleds="adm", AuthorityName="总监", AuthorityID="majordomo" },
                     new Authoritys{ Roleds="adm", AuthorityName="副总", AuthorityID="deputy" },
                     // 超级管理员
                     new Authoritys{ Roleds="system", AuthorityName="超级管理员", AuthorityID="sys" },
                     new Authoritys{ Roleds="sys", AuthorityName="数据库DBA", AuthorityID="dba" },
                     new Authoritys{ Roleds="sys", AuthorityName="系统调试员", AuthorityID="debugg" },
                     new Authoritys{ Roleds="sys", AuthorityName="老板", AuthorityID="boss" },
                     new Authoritys{ Roleds="sys", AuthorityName="system", AuthorityID="system" },
                     //收银员   
                     new Authoritys{ Roleds="casher", AuthorityName="收银员", AuthorityID="cas" },
                     new Authoritys{ Roleds="cas", AuthorityName="业务员", AuthorityID="salesman" },
                };
                foreach (Authoritys c in authon)
                {
                    db.Authoritys.Add(c);
                }
                db.SaveChanges();
            }

        }
    }
}
