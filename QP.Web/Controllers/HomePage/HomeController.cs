using System;
using System.Collections.Generic;
using System.Linq;
using QP.Cashier.Utility;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QP.Cashier_Service;

namespace QP.CashierSystem_Web.Controllers.HomePage
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubNavs(string id = "0")
        {
            Cliet clite = new Cliet();
            JieDian root = new JieDian();
            root.Name = "根节点";
            root.Id = 0;
            var list = new List<JieDian>();
            clite.creatTheTree(id, root, out list); //根节点的parentBh值为"0"
            string tree = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return Json(list);
        }




        /// <summary>
        ///   组合Json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult LeftNav(string id)
        {
            var DbContext = GlobalDBContext.Instance();
            Cliet clite = new Cliet();
            JieDian root = new JieDian();
            root.Name = "根节点";
            root.Id = 0;
            var list = new List<JieDian>();
            clite.creatTheTree(id, root, out list); //根节点的parentBh值为"0"
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return Json(json);

        }



        public IActionResult FristNav()
        {
            return View();
        }

        /// <summary>
        /// 动态生成表格的数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetRoles(int? page, int? rows)
        {
            page = page == null ? 1 : page; //第几页
            rows = rows == null ? 10 : rows; //行数    
            var db = GlobalDBContext.Instance();
            var json = db.Staffs.Join(db.Operations, a => a.OperationID, b => b.OperationID, (a, b) => new
            {
                a.StaffBirth,
                a.StaffBirthType,
                a.StaffEntryTime,
                a.StaffIdentity,
                a.StaffName,
                a.StaffPhone,
                a.StaffSex,
                a.AcrossTheStore,
                a.StaffDuty,
                b.StaffCreateTime,
                b.StaffCreator,
                b.StaffUpdateTime,
                b.StaffModifyUser
            }).OrderBy(p => p.StaffName).Skip(Convert.ToInt32(rows) * Convert.ToInt32(page) - 1).Take(Convert.ToInt32(rows));
            //DataGridJson obj = new DataGridJson();
            //obj.rows = json;
            //obj.total = db.Staffs.Count();
            return Json(json);
        }

        public IActionResult SecondNav()
        {
            return View();
        }
    }
}