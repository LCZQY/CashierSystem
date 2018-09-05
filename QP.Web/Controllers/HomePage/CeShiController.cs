using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Npoi.Core.XSSF.UserModel;
using Npoi.Core.SS.UserModel;
using System.Reflection;
using System;
using System.Diagnostics;
using DocumentFormat.OpenXml.Bibliography;
using System.Text;
using QP.Cashier.Utility;
namespace QP.CashierSystem_Web.Controllers.HomePage
{
    public class CeShiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }       




    } 
}