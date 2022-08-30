using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.Entity.Concrete;
using MuhasebeMaster.MvcWebUI.Identity;
using MuhasebeMaster.MvcWebUI.Models;
using System;
using System.Security.Claims;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    [Authorize]
    public class ProdController : Controller
    {
        IProdService _prodService;
        IHostingEnvironment _env;
        private UserManager<AppIdentityUser> _userManager;

        public ProdController(IProdService prodService, IHostingEnvironment env, UserManager<AppIdentityUser> userManager)
        {
            _prodService = prodService;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult GetProducts()
        {
            var prodViewModel = new ProdViewModel
            {
                Products = _prodService.GetProductWithDate()
             };
            return View(prodViewModel);
        }

        public IActionResult GetProductDetail(Guid id)
        {
            if (id != null)
            {
                var productIsValid = _prodService.GetById(id);
                var prodViewModel = new ProdViewModel
                {
                    Product = productIsValid
                };
                return View(prodViewModel);
            }
            return RedirectToAction("GetProducts");
        }

        public IActionResult Add(ProdViewModel productViewModel)
        {
            //var userId = ((ClaimsIdentity)User.Identity).FindFirst("Id").Value; //current user info
            //var user = await _userManager.FindByIdAsync(userId);
            if (ModelState.IsValid)
            {
                var productIsValid = _prodService.GetByName(productViewModel.Product.Name);
                if (productIsValid != null)
                {
                    return RedirectToAction("GetProducts");
                }
                var productForAdd = new Prod
                {
                    Id = Guid.NewGuid(),
                    AddedDate = DateTime.Now,
                    Name = productViewModel.Product.Name,
                    Model = productViewModel.Product.Model,
                    Description = productViewModel.Product.Description,
                    Quantity = productViewModel.Product.Quantity,
                    UnitPrice = productViewModel.Product.UnitPrice,
                    TotalPrice = productViewModel.Product.UnitPrice * Convert.ToDecimal(productViewModel.Product.Quantity),
                    ModifiedDate = DateTime.Now
                };
                try
                {
                    var addedProduct = _prodService.Add(productForAdd);

                    return RedirectToAction("GetProducts");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("GetProducts");
                }
            }
            return RedirectToAction("GetProducts");
        }

        public JsonResult Edit(Guid id)
        {
            if (id != null)
            {
                var result = _prodService.GetById(id);

                return Json(result);
            }
            return Json(0);
        }

        [HttpPost]
        public IActionResult Edit(ProdViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var productIsValid = _prodService.GetById(productViewModel.Product.Id);
                if (productIsValid == null)
                {
                    return RedirectToAction("GetProducts");
                }
                var productForUpdate = new Prod
                {
                    Name = productViewModel.Product.Name,
                    Model = productViewModel.Product.Model,
                    Description = productViewModel.Product.Description,
                    Quantity = productViewModel.Product.Quantity,
                    UnitPrice = productViewModel.Product.UnitPrice,
                    TotalPrice = productViewModel.Product.UnitPrice * Convert.ToDecimal(productViewModel.Product.Quantity),
                    AddedDate = productIsValid.AddedDate,
                    Id = productIsValid.Id,
                    ModifiedDate = DateTime.Now
                };
                try
                {
                    _prodService.Update(productForUpdate);
                    return RedirectToAction("GetProducts");
                }
                catch (Exception)
                {
                    return RedirectToAction("GetProducts");
                }
            }
            return RedirectToAction("GetProducts");
        }

        public JsonResult Delete(Guid id)
        {
            if (id != null)
            {
                var productIsValid = _prodService.GetById(id);
                if (productIsValid == null)
                {
                    return Json(0);
                }
                _prodService.Delete(productIsValid);
                return Json(1);
            }
            return Json(0);
        }

        public JsonResult SoftDelete(Guid id)
        {
            if (id != null)
            {
                var productIsValid = _prodService.GetById(id);
                if (productIsValid == null)
                {
                    return Json(0);
                }
                //productIsValid.IsActive = false;
                _prodService.Update(productIsValid);
                return Json(1);
            }
            return Json(0);
        }

    }
}
