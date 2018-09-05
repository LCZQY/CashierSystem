using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QP.Cashier_Model.CreateEntity;
using QP.Cashier_Service.SqlHelp;
using QP.Cashier_Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QP.Cashier_UI.Controllers.HomePage
{

    /// <summary>
    ///  分布创建视图
    /// </summary>
    public class TeoriaController : Controller
    {
        public IActionResult Index()
        {
            var db = GlobalDBContext.Instance();
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            foreach (var item in db.Shops)
            {
                keyValues.Add(item.ShopID, item.ShopName);
            }
            ViewData["SelectShop"] = new SelectList(keyValues, "Key", "Value");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("StaffName,StaffSex,StaffBirthType,StaffPhone,StaffBirth,StaffIdentity,JobNumber,Password,StaffDuty,StaffEntryTime,ShopID")]Staffs staffs)
        {


            var db = GlobalDBContext.Instance();
            Random sj = new Random();

            /// 用户登陆过后加入 操作人的信息
            staffs.Roleds = "测试老板";
            staffs.AuthorityID = sj.Next(1000, 10000).ToString();
            staffs.StaffID = Guid.NewGuid().ToString();
            staffs.WagesID = sj.Next(1000, 10000).ToString();
            staffs.OperationID = sj.Next(1000, 10000).ToString();


            HelpStaffs helpStaffs = new HelpStaffs();
            var json = helpStaffs.AddEntity(staffs);
            return Json(true);

        }

        /// <summary>
        ///  判断注册用户名是否存在 【本方法由模型直接调用 remote】
        /// </summary>
        /// <returns></returns>
        public IActionResult UserExist(string name)
        {
            HelpStaffs helpStaffs = new HelpStaffs();
            var exist = helpStaffs.GetMsg(u => u.JobNumber == name);
            if (exist) return Json(data: true);
            return Json(data: "该员工信息已经存在");

        }

    }
}