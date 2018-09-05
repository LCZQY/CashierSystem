using System;
using System.Linq;
using System.IO;
using System.Data;
using OfficeOpenXml;
using QP.Cashier.Utility;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using QP.Cashier_Service.SqlHelp;
using QP.Cashier_Service.Paging;

namespace QP.CashierSystem_Web.Controllers.HomePage
{
    public class matterController : Controller
    {
        private int page = 0;//页数
        private int rows = 0; //行数
        private string export = string.Empty; //导出
        private string Queryid = string.Empty; // 时间查询字段
        private string FilesName { get; set; }
        private HelpStaffs helpStaffs = new HelpStaffs();
        private string EndDate = "0001-01-01T00:00:00";
        private string StartDate = "0001-01-01T00:00:00";

        private string SelectVal = string.Empty;
        private string InputVals = string.Empty; // 输入查询字符

        private string shopID = string.Empty; //门店ID
        private IHostingEnvironment _hostingEnvironment; //excel 上下文

        public matterController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  字段筛选条件 ：
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSelectData()
        {
            // 优化？ 是否要查找数据库？
            Hashtable hashtable = new Hashtable() { };
            hashtable.Add("StaffName", "姓名");
            hashtable.Add("StaffBirth", "生日");
            hashtable.Add("StaffBirthType", "生日类型");
            hashtable.Add("StaffIdentity", "身份证");
            hashtable.Add("StaffPhone", "手机");
            hashtable.Add("StaffSex", "性别");
            hashtable.Add("AcrossTheStore", "是否跨店");
            hashtable.Add("StaffDuty", "职位");
            hashtable.Add("StaffCreator", "创建人");
            hashtable.Add("StaffCreateTime", "创建时间");
            hashtable.Add("StaffUpdateTime", "修改时间");
            hashtable.Add("StaffModifyUser", "修改用户");
            return Json(hashtable);
        }


        /// <summary>
        /// 动态生成表格的数据
        /// </summary>
        /// <param name="page"></param>
         /// <param name="rows"></param>
        /// <returns></returns>       
        public ActionResult GetJson(int? page, int? rows)
        {
            try
            {
                page = page == null ? 1 : page; //第几页
                rows = rows == null ? 10 : rows; //行数                 
                try
                {
                    //后台接受前台数据是一个对象，所以先要实例化Tostring()
                    EndDate = Request.Form["EndDate"].ToString() == string.Empty ? EndDate : Request.Form["EndDate"].ToString();
                    StartDate = Request.Form["StartDate"].ToString() == string.Empty ? StartDate : Request.Form["StartDate"].ToString();
                    Queryid = Request.Form["Queryid"].ToString() == string.Empty ? Queryid : Request.Form["Queryid"].ToString();
                    SelectVal = Request.Form["SelectVal"].ToString() == string.Empty ? SelectVal : Request.Form["SelectVal"].ToString();
                    InputVals = Request.Form["inputVals"].ToString() == string.Empty ? InputVals : Request.Form["inputVals"].ToString();
                    shopID = Request.Form["shopID"].ToString() == string.Empty ? "" : Request.Form["shopID"].ToString();

                }
                catch (Exception ex)
                {
                    return Json(data: new { exs = ex.Message });
                }

                StaffInfoparam staffInfoparam = new StaffInfoparam()
                {
                    _endDate = DateTime.Parse(EndDate), //结束时间
                    _startDate = DateTime.Parse(StartDate),//起始时间
                    _queryName = Queryid, //时间查询字段
                    _rows = (int)rows,//行数
                    _page = (int)page,//页数
                    _total = 0,//总行数
                    _fileName = "", //导出文件名
                    _selectVal = SelectVal, //输入查询字段
                    _inputVals = InputVals, //用户信息
                    _shopID = shopID // 门店ID
                };

               // return Json(data: new { shopids = staffInfoparam._shopID }); //??? 单独测试，存在数据
                var json = helpStaffs.Contaion(_hostingEnvironment, staffInfoparam, export);
                return Json(new { rows = json, total = staffInfoparam._total });
            }
            catch (Exception ex)
            {
                return Json(ResultMsg.FormatResult(ex));
            }
        }



        /// <summary>
        ///  导出数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetExcel()
        {
            export = Request.Form["export"];
            StaffInfoparam staffInfoparam = new StaffInfoparam()
            {
                _endDate = DateTime.Parse(EndDate),
                _startDate = DateTime.Parse(StartDate),
                _queryName = Queryid,
                _rows = (int)rows,
                _page = (int)page,
                _total = 0,
                _fileName = ""
            };

            var json = helpStaffs.Contaion(_hostingEnvironment, staffInfoparam, export);
            if (staffInfoparam._fileName == "")
            {
                return Json(ResultMsg.FormatResult(404, "没有找到该文件啊", "处理有误"));
            }

            return File(staffInfoparam._fileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }


    }
}
