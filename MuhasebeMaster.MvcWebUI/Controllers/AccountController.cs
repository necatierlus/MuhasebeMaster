using Microsoft.AspNetCore.Mvc;
using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.Entity.Concrete;
using MuhasebeMaster.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult GetCustomers()
        {
            var accountViewModel = new AccountViewModel
            {
                Accounts = _accountService.GetCustomersByDate()
            };
            return View(accountViewModel);
        }

        public IActionResult GetTenants()
        {
            var accountViewModel = new AccountViewModel
            {
                Accounts = _accountService.GetTenantsByDate()
            };
            return View(accountViewModel);
        }

        public IActionResult GetTrademen()
        {
            var accountViewModel = new AccountViewModel
            {
                Accounts = _accountService.GetTrademenByDate()
            };
            return View(accountViewModel);
        }

        public IActionResult GetAccountDetail(Guid id)
        {
            if (id != null)
            {
                var accounts = _accountService.GetById(id);
                var accountViewModel = new AccountViewModel
                {
                    Account = accounts
                };
                return View(accountViewModel);
            }
            return View();
        }

        public IActionResult Add(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var accountIsValid = _accountService.GetById(accountViewModel.Account.Id);
                if (accountIsValid != null)
                {
                    throw new Exception("Hesap mevcut!");
                }
                var accountForAdd = new Account
                {
                    Id = Guid.NewGuid(),
                    AddedDate = DateTime.Now,
                    Fullname = accountViewModel.Account.Fullname,
                    Phone = accountViewModel.Account.Phone,
                    City = accountViewModel.Account.City,
                    District = accountViewModel.Account.District,
                    Address = accountViewModel.Account.Address,
                    AccountType = accountViewModel.Account.AccountType,
                    CostType = accountViewModel.Account.CostType,
                    IsActive = true
                };
                try
                {
                    var addedAccount = _accountService.Add(accountForAdd);
                    if (accountViewModel.Account.AccountType == "Customer")
                    {
                        return RedirectToAction("GetCustomers");
                    }
                    if (accountViewModel.Account.AccountType == "Tenant")
                    {
                        return RedirectToAction("GetTenants");
                    }
                    if (accountViewModel.Account.AccountType == "Trademen")
                    {
                        return RedirectToAction("GetTrademen");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Bir hata oluştu!");
                }
            }
            if (accountViewModel.Account.AccountType == "Tenant")
            {
                return RedirectToAction("GetTenants");
            }
            if (accountViewModel.Account.AccountType == "Trademen")
            {
                return RedirectToAction("GetTrademen");
            }
            return RedirectToAction("GetCustomers");
        }

        public JsonResult Edit(Guid id)
        {
            if (id != null)
            {
                var result = _accountService.GetById(id);

                return Json(result);
            }
            return Json(0);
        }

        [HttpPost]
        public IActionResult Edit(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var accountIsValid = _accountService.GetById(accountViewModel.Account.Id);
                if (accountIsValid == null)
                {
                    throw new Exception("An error occured!");
                }
                var accountForUpdate = new Account
                {
                    Fullname = accountViewModel.Account.Fullname,
                    Phone = accountViewModel.Account.Phone,
                    City = accountViewModel.Account.City,
                    District = accountViewModel.Account.District,
                    Address = accountViewModel.Account.Address,
                    AccountType = accountViewModel.Account.AccountType,
                    CostType = accountViewModel.Account.CostType,
                    IsActive = accountIsValid.IsActive,
                    AddedDate = accountIsValid.AddedDate,
                    Id = accountIsValid.Id,
                    ModifiedDate = DateTime.Now
                };
                try
                {
                    _accountService.Update(accountForUpdate);
                    if (accountViewModel.Account.AccountType == "Customer")
                    {
                        return RedirectToAction("GetCustomers");
                    }
                    if (accountViewModel.Account.AccountType == "Tenant")
                    {
                        return RedirectToAction("GetTenants");
                    }
                    if (accountViewModel.Account.AccountType == "Trademen")
                    {
                        return RedirectToAction("GetTrademen");
                    }
                }
                catch (Exception)
                {
                    throw new Exception("An error occured!");
                }
            }
            return RedirectToAction("GetCustomers");
        }

        public JsonResult Delete(Guid id)
        {
            if (id != null)
            {
                var accountIsValid = _accountService.GetById(id);
                if (accountIsValid == null)
                {
                    return Json(0);
                }
                accountIsValid.IsActive = false; //soft delete
                _accountService.Update(accountIsValid);
                return Json(1);
            }
            return Json(0);
        }
    }
}
