using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CeShi.Models;
using Microsoft.AspNetCore.Mvc;
using QP.Cashier.Utility.ControllerBase;
using QP.Cashier_Service;

namespace QP.CashierSystem_Web.Areas.System.Controllers
{
    [Area("System")]
    public class HomeController : SystemBase
    {
        public IActionResult Index()
        {
            //Initialize initialize = new Initialize();
            var db = GlobalDBContext.Instance();

            //var db = CashierSystem_Service.GlobalDBContext.Instance();
            //db.Add(new QP.CashierSystem_Model.Navs { Pid = 0, Area = "System", Controller = "home", Action = "index", IsNavi = true, IsHiddenMethod = false, CreateDate = DateTime.Now });

            //db.SaveChanges();

            //db.Add(new QP.CashierSystem_Model.Navs { Pid = 1, Area = "System", Controller = "home", Action = "index", IsNavi = true, IsHiddenMethod = false, CreateDate = DateTime.Now });
            //db.SaveChanges();

            //生成树形菜单 
            //var list = CashierSystem_Service.GlobalDBContext.Instance().Navs.Where( n => n.Area == "system").ToList();
            //var rst = QP.Cashier.Utility.Array2Tree.ToTree(list);


            //调用写好的类，序列化成JSON格式
            Cliet clite = new Cliet();
            JieDian root = new JieDian();
            //root.Name = "根节点";
            //root.Id = 0;
            var list = new List<JieDian>();
            clite.creatTheTree("0", root, out list); //根节点的parentBh值为"0"
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return Json(json);
            
        }
        public bool IsReusable
        {
            get
            {
                return false;

            }
        }
    }
}