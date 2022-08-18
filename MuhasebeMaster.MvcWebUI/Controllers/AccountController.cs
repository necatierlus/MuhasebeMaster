using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.Core.Constant;
using MuhasebeMaster.Entity.Concrete;
using MuhasebeMaster.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MuhasebeMaster.Core.Constant.Enums;

namespace MuhasebeMaster.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _accountService;
        ITransactionService _transactionService;
        IProdService _prodService;
        ITillService _tillService;

        public AccountController(IAccountService accountService, ITransactionService transactionService, IProdService prodService, ITillService tillService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
            _prodService = prodService;
            _tillService = tillService;
        }

        public IActionResult GetCustomers()
        {
            ViewBag.AccountTypes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            ViewBag.CostTypes = Enum.GetValues(typeof(CostType)).Cast<CostType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            var accountViewModel = new AccountViewModel
            {
                Accounts = _accountService.GetCustomersByDate()
            };

            return View(accountViewModel);
        }

        public IActionResult GetTenants()
        {
            ViewBag.AccountTypes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            ViewBag.CostTypes = Enum.GetValues(typeof(CostType)).Cast<CostType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            var accountViewModel = new AccountViewModel
            {
                Accounts = _accountService.GetTenantsByDate()
            };
            return View(accountViewModel);
        }

        public IActionResult GetTrademen()
        {
            ViewBag.AccountTypes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            ViewBag.CostTypes = Enum.GetValues(typeof(CostType)).Cast<CostType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

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
                var trans = _transactionService.GetTransactionsByAccount(id);
                var accountViewModel = new AccountViewModel
                {
                    Account = accounts,
                    Transactions = trans
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

        public IActionResult AddTransaction(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var account = _accountService.GetById(accountViewModel.Account.Id);
                var prod = _prodService.GetById(accountViewModel.Account.Id);   

                var transactionForAdd = new Transaction
                {
                    Id = Guid.NewGuid(),
                    AccountId = account.Id,
                    ProductId = prod.Id, 
                    Text = null,
                    Quantity = accountViewModel.Transaction.Quantity,
                    Price = accountViewModel.Transaction.Price.ToString().Contains("-")  ? -accountViewModel.Transaction.Price : accountViewModel.Transaction.Price,
                    Description = accountViewModel.Transaction.Description,
                    AddedDate = DateTime.Now,
                    IsActive = true,
                    Income = accountViewModel.Transaction.Price.ToString().Contains("-") ? true : false
                };
                try
                {
                    var addedAccount = _transactionService.Add(transactionForAdd);
                    Guid id = addedAccount.Id;
                    var till = new Till
                    {
                        Id = Guid.NewGuid(),
                        AddedDate =  DateTime.Now,
                        TransactionId = id,
                        AccountId = account.Id,
                        PaymentId = Guid.Empty,
                        Price = accountViewModel.Transaction.Price.ToString().Contains("-") ? -accountViewModel.Transaction.Price : accountViewModel.Transaction.Price,
                        CostType = account.CostType,
                        IsTill = false,
                        IsActive = true
                    };
                    _tillService.Add(till);
                    return Redirect("/Account/GetAccountDetail/" + accountViewModel.Account.Id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Bir hata oluştu!");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditTransaction(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var account = _accountService.GetById(accountViewModel.Account.Id);
                var transaction = _transactionService.GetById(accountViewModel.Transaction.Id);
                if (transaction == null)
                {
                    throw new Exception("An error occured!");
                }
                var transactionForUpdate = new Transaction
                {
                    Id = transaction.Id,
                    AccountId = transaction.AccountId,
                    ProductId = accountViewModel.Transaction.ProductId,
                    Text = null,
                    Quantity = accountViewModel.Transaction.Quantity,
                    Price = accountViewModel.Transaction.Price.ToString().Contains("-") ? -accountViewModel.Transaction.Price : accountViewModel.Transaction.Price,
                    Description = accountViewModel.Transaction.Description,
                    AddedDate = transaction.AddedDate,
                    IsActive = transaction.IsActive,
                    Income = accountViewModel.Transaction.Price.ToString().Contains("-") ? true : false
                };
                try
                {
                    _transactionService.Update(transactionForUpdate);
                    var tillById = _tillService.GetByTransaction(transaction.Id);
                    var till = new Till
                    {
                        Id = tillById.Id,
                        AddedDate = tillById.AddedDate,
                        TransactionId = tillById.Id,
                        AccountId = tillById.AccountId,
                        PaymentId = tillById.PaymentId,
                        Price = accountViewModel.Transaction.Price.ToString().Contains("-") ? -accountViewModel.Transaction.Price : accountViewModel.Transaction.Price,
                        CostType = tillById.CostType,
                        IsTill = tillById.IsTill,
                        IsActive = tillById.IsActive
                    };
                    _tillService.Update(till);
                    return Redirect("/Account/GetAccountDetail/" + accountViewModel.Account.Id);
                }
                catch (Exception)
                {
                    throw new Exception("An error occured!");
                }
            }
            return View();
        }

        public JsonResult GetTransactions()
        {
            //var trans = _transactionService.GetTransactionsByAccount(id);
            //var all = from p in _conte 

            return Json(0);
        }


        public JsonResult DeleteTransaction(Guid id)
        {
            if (id != null)
            {
                var transaction = _transactionService.GetById(id);
                if (transaction == null)
                {
                    return Json(0);
                }
                transaction.IsActive = false; //soft delete
                _transactionService.Update(transaction);
                var tillById = _tillService.GetByTransaction(transaction.Id);
                tillById.IsActive = false;
                _tillService.Update(tillById);
                return Json(1);
            }
            return Json(0);
        }

    }
}
