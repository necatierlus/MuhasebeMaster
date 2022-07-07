using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.Entity.Concrete;
using MuhasebeMaster.MvcWebUI.Models;
using System;

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
            var products = _prodService.GetProductWithDate();
            return View(products);
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
            if (ModelState.IsValid)
            {
                var productIsValid = _prodService.GetByName(productViewModel.Product.Name);
                if (productIsValid != null)
                {
                    return RedirectToAction("GetProducts");
                }
                var productForAdd = new Prod
                {
                    AddedDate = DateTime.Now,
                    AddedBy = "Cihan Aybar",
                    CategoryId = productViewModel.Product.CategoryId,
                    Explanation = productViewModel.Product.Explanation,
                    Height = productViewModel.Product.Height,
                    Name = productViewModel.Product.Name,
                    Weight = productViewModel.Product.Weight,
                    Width = productViewModel.Product.Width
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
                    AddedBy = productIsValid.AddedBy, 
                    AddedDate = productIsValid.AddedDate,
                    CategoryId = productViewModel.Product.CategoryId,
                    Explanation = productViewModel.Product.Explanation,
                    Height = productViewModel.Product.Height,
                    Name = productViewModel.Product.Name,
                    Weight = productViewModel.Product.Weight,
                    Width = productViewModel.Product.Width,
                    Id = productIsValid.Id
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
                productIsValid.IsActive = false;
                _prodService.Update(productIsValid);
                return Json(1);
            }
            return Json(0);
        }

    }
}
