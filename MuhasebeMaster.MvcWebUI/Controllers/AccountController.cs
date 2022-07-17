using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult GetCustomers()
        {
            return View();
        }

        public IActionResult GetTenants()
        {
            return View();
        }

        public IActionResult GetTrademen()
        {
            return View();
        }
    }
}
