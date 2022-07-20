using Microsoft.AspNetCore.Mvc;
using MuhasebeMaster.Business.Abstract;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    public class TillController : Controller
    {
        ITillService _tillService;

        public TillController(ITillService tillService)
        {
            _tillService = tillService;
        }

        public IActionResult TillTL()
        {
            ViewBag.TL = _tillService.GetTillTLBalance();
            return View();
        }

        public IActionResult TillDollar()
        {
            ViewBag.DOLAR = _tillService.GetTillDollarBalance();
            return View();
        }

    }
}
