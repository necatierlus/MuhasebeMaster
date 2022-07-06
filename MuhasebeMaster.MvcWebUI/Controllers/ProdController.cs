using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MuhasebeMaster.Business.Abstract;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    [Authorize]
    public class ProdController : Controller
    {
        IProdService _prodService;
        IHostingEnvironment _env;

        public ProdController(IProdService prodService, IHostingEnvironment env)
        {
            _prodService = prodService;
            _env = env;
        }

        public IActionResult GetProducts()
        {
            var products = _prodService.GetList();
            return View(products);
        }
    }
}
