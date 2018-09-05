using QP.CashierSystem_Model;
using QP.CashierSystem_Service.QP.CashierSystem_IDAL;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QP.CashierSystem_Service.Paging;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

using Microsoft.AspNetCore.Hosting;

namespace QP.Cashier.Server.QP.SqlHelp
{
    class Sqlhelps {  }

    public class HelpStaffs : BaseDal<Staffs>, IBaseDal<Staffs>
    {        

        /// <summary>
        ///  分页查询数据
        /// </summary>
        /// <param name="infoparam"></param>
        /// <param name="export"></param>
        /// <returns></returns>
        public dynamic Contaion(IHostingEnvironment _hostingEnvironment,StaffInfoparam infoparam,string export)
        {
            
            var db = GlobalDBContext.Instance();
            string QueryfieldName = infoparam._queryName;
            DateTime startDate = infoparam._startDate;
            DateTime endDate = infoparam._endDate;
            var Rowset = (from S in db.Staffs
                          join O in db.Operations on S.OperationID equals O.OperationID
                          orderby S.StaffID
                          select new
                          {
                              AuthorityID = S.AuthorityID,
                              StaffBirth = S.StaffBirth,
                              StaffBirthType = S.StaffBirthType,
                              StaffEntryTime = S.StaffEntryTime,
                              StaffIdentity = S.StaffIdentity,
                              StaffName = S.StaffName,
                              StaffPhone = S.StaffPhone,
                              StaffSex = S.StaffSex,
                              AcrossTheStore = S.AcrossTheStore,
                              StaffDuty = S.StaffDuty,
                              StaffCreateTime = O.StaffCreateTime,
                              StaffCreator = O.StaffCreator,
                              StaffUpdateTime = O.StaffUpdateTime,
                              StaffModifyUser = O.StaffModifyUser
                          });
            /// 按照时间筛选
            if (!string.IsNullOrEmpty(infoparam._queryName) && infoparam._endDate != null && infoparam._startDate !=null ) {
                switch (QueryfieldName)
                {
                    case "StaffBirth":
                        Rowset.Where(S => S.StaffBirth >= startDate && S.StaffBirth <= endDate);
                        break;
                    case "StaffEntryTime":
                        Rowset.Where(S => S.StaffEntryTime >=startDate && S.StaffEntryTime <=endDate);
                        break;
                    case "StaffCreateTime":
                        Rowset.Where(S => S.StaffCreateTime >=startDate && S.StaffCreateTime <=endDate);
                        break;
                    case "StaffUpdateTime":
                        Rowset.Where(S => S.StaffUpdateTime >=startDate && S.StaffUpdateTime <=endDate);
                        break;
                }
            }

            //按照用户输入筛选
            if (!string.IsNullOrEmpty(infoparam._selectVal) && !string.IsNullOrEmpty(infoparam._inputVals))
            {
                switch (infoparam._selectVal)
                {
                    case "StaffName":
                        Rowset.Where(S => S.StaffName.ToString().Contains(infoparam._inputVals));
                        break;
                    case "StaffBirth":
                        Rowset.Where(S=>S.StaffBirth.ToString().Contains(infoparam._inputVals));
                        break;
                    case "StaffEntryTime":
                        Rowset.Where(S => S.StaffEntryTime.ToString().Contains(infoparam._inputVals));
                        break;
                    case "StaffCreateTime":
                        Rowset.Where(S => S.StaffCreateTime.ToString().Contains(infoparam._inputVals));
                        break;
                    case "StaffUpdateTime":
                        Rowset.Where(S => S.StaffUpdateTime.ToString().Contains(infoparam._inputVals));
                        break;
                }
            }

            ///导出报表
            if (export  != "")
            {
                DataTable table = new DataTable();//创建表                         
                List<string> Columns = new List<string>() { "姓名", "性别", "职位", "生日类型", "生日", "身份证", "手机", "是否跨店", "入职时间", "创建时间", "创建人", "修改时间", "修改用户" };
                table = CreateTable.ReturnColuns(table, Columns);
                foreach (var item in Rowset)
                {
                    table.Rows.Add(new object[] { item.StaffName, item.StaffSex, item.StaffDuty, item.StaffBirthType, item.StaffBirth, item.StaffIdentity, item.StaffPhone, item.AcrossTheStore, item.StaffEntryTime, item.StaffCreateTime, item.StaffCreator, item.StaffUpdateTime, item.StaffModifyUser });
                }
                infoparam._fileName=ExportExecl.CrateExecl(_hostingEnvironment,table);
            }
            infoparam._total = Rowset.Count();
            return Rowset.OrderBy(p => p.AuthorityID).Skip(Convert.ToInt32(infoparam._rows) * Convert.ToInt32(infoparam._page) - 1).Take(Convert.ToInt32(infoparam._rows));
        }
    }

}
