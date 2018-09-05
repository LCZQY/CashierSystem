using System;
using System.Linq;

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization; //身份验证
using Microsoft.AspNetCore.Authentication; //身份验证
using Microsoft.AspNetCore.Authentication.Cookies; //身份验证
using QP.Cashier.Utility;
using Microsoft.AspNetCore.Http;

using System.Collections;
using QP.Cashier_Service.SqlHelp;

namespace QP.Cashier_UI.Controllers.LogIn
{

    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            //Initialize db = new Initialize();
            return View();
        }

        // [ValidateAntiForgeryToken]     
        [HttpPost]
        public async Task<IActionResult> IndexLogin(string LogNumber, string PassWord)
        {
            HelpStaffs StaffsDb = new HelpStaffs();
            var user = StaffsDb.LoadEntityies(u => u.JobNumber == LogNumber);
            if (user == null)
            {
                return Json(ResultMsg.FormatResult(400, "存在错误！", "不存在该用户！"));
            }
            else
            {
                user = StaffsDb.LoadEntityies(u => u.JobNumber == LogNumber && u.Password == PassWord);
                if (user == null)
                {
                    return Json(ResultMsg.FormatResult(400, "存在错误！", "密码错误"));
                }

                foreach (var item in user.ToList())
                {
                    ConstVal.Roles = item.Roleds.ToString();
                }
               
                var claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //记住用户名
                claims.AddClaim(new Claim(ClaimTypes.Name, LogNumber));
                //记录用户角色
                claims.AddClaim(new Claim(ClaimTypes.Role, ConstVal.Roles));
                //保存用户信息
                claims.AddClaim(new Claim(ClaimTypes.IsPersistent, $"{true}"));
                var claimsPrincipal = new ClaimsPrincipal(claims);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Json(ResultMsg.FormatResult(200));
            }

        }

    }
}
///知识点
///如果没有模板则MVc的验证提示无效
///添加Remote特性
///[Remote("CheckUserName", "ControllerName", ErrorMessage = "用户名已存在")