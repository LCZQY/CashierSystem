using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QP.Cashier.Utility;
using QP.Cashier.Utility.ControllerBase;

namespace QP.CashierSystem_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : AdminBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}