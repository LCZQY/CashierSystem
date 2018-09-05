using System;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using QP.Cashier_Service.SqlHelp;

namespace QP.Cashier_Service
{
    public static  class ExistUser
    {  
        public static  bool LoginIndex(string JobNumber, string Password)
        {
       
            HelpStaffs StaffsDb = new HelpStaffs();
            var user = StaffsDb.LoadEntityies(u => u.JobNumber == JobNumber && u.Password == Password);
            if (user != null)
            {
                //var claim = new Claim[]{
                // new Claim(ClaimTypes.Role),
                // new Claim(ClaimTypes.Name,"郑强勇")
                //     };

                //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claim, "Cookie")));
                ////给User赋值 
                //var claPris = new ClaimsPrincipal();
                //claPris.AddIdentity(new ClaimsIdentity(claim));
                //HttpContext.User = claPris;
            }
            else
            {
                return false;

            }



            // if (JobNumber.Trim().ToLower() == dbJob && Password.Trim().ToLower() == dbPass)
            // {
            var claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //记住用户名
                claims.AddClaim(new Claim(ClaimTypes.Name, JobNumber));
                //记录用户角色
                claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                //保存用户信息
                claims.AddClaim(new Claim(ClaimTypes.IsPersistent, $"{true}"));
                var claimsPrincipal = new ClaimsPrincipal(claims);
                //await HttpContext.SignInAsync(claimsPrincipal);

                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }                   
    }
}
