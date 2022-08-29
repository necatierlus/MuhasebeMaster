using Microsoft.AspNetCore.Http;
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

            var accountViewModel = new AccountViewModel();
            accountViewModel.Accounts = _accountService.GetCustomersByDate();

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
            HttpContext.Session.SetString("AccountId", id.ToString());
            if (id != null)
            {
                var accounts = _accountService.GetById(id);
                var accountViewModel = new AccountViewModel();
                accountViewModel.Account = accounts;
                ViewBag.Balance = 0;
                var result = _accountService.GetBalance(id);
                ViewBag.Balance = result;

                ViewBag.ProdModels = _accountService.GetProductsByModelNo().Select(a => new SelectListItem
                {
                    Text = a.Model,
                    Value = a.Id.ToString()
                });
                ViewBag.PaymentTypes = Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();
                ViewBag.SalesTypes = Enum.GetValues(typeof(SalesType)).Cast<SalesType>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();

                return View(accountViewModel);
            }
            return View();
        }

        [HttpPost]
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
                    AccountType = accountViewModel.Account.AccountType == "0" ? "Müşteri" : (accountViewModel.Account.AccountType == "1" ? "Kiracı" : (accountViewModel.Account.AccountType == "2" ? "Esnaf" : "")),
                    CostType = accountViewModel.Account.CostType == "0" ? "TL" : "DOLAR",
                    IsActive = true
                };
                try
                {
                    var addedAccount = _accountService.Add(accountForAdd);
                    if (accountViewModel.Account.AccountType == "0")
                    {
                        return RedirectToAction("GetCustomers");
                    }
                    if (accountViewModel.Account.AccountType == "1")
                    {
                        return RedirectToAction("GetTenants");
                    }
                    if (accountViewModel.Account.AccountType == "2")
                    {
                        return RedirectToAction("GetTrademen");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Bir hata oluştu!");
                }
            }
            if (accountViewModel.Account.AccountType == "1")
            {
                return RedirectToAction("GetTenants");
            }
            if (accountViewModel.Account.AccountType == "2")
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
                    AccountType = accountIsValid.AccountType,
                    CostType = accountIsValid.CostType,
                    //AccountType = accountViewModel.Account.AccountType == Enums.AccountType.Musteri.ToString() ? "Müşteri" : (accountViewModel.Account.AccountType == Enums.AccountType.Kiraci.ToString() ? "Kiracı" : (accountViewModel.Account.AccountType == Enums.AccountType.Esnaf.ToString() ? "Esnaf" : "")),
                    //CostType = accountViewModel.Account.CostType == Enums.CostType.TL.ToString() ? "TL" : "DOLAR",
                    IsActive = accountIsValid.IsActive,
                    AddedDate = accountIsValid.AddedDate,
                    Id = accountIsValid.Id,
                    ModifiedDate = DateTime.Now
                };
                try
                {
                    _accountService.Update(accountForUpdate);
                    if (accountIsValid.AccountType == "Müşteri")
                    {
                        return RedirectToAction("GetCustomers");
                    }
                    if (accountIsValid.AccountType == "Kiracı")
                    {
                        return RedirectToAction("GetTenants");
                    }
                    if (accountIsValid.AccountType == "Esnaf")
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

        public IActionResult AddTransaction(TransactionViewModel model, string drpProduct)
        {
            Guid accId = Guid.Parse(HttpContext.Session.GetString("AccountId"));
            var acc = _accountService.GetById(accId);
            //var prod = _prodService.GetByName(model.Prod.Name);

            var transactionForAdd = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = accId,
                ProductId = model.Transaction.ProductId != null ? model.Transaction.ProductId : Guid.Empty,
                Text = model.Transaction.Text,
                Quantity = model.Transaction.Quantity,
                Price = model.Transaction.Price,
                Description = model.Transaction.Description,
                AddedDate = DateTime.Now,
                IsActive = true,
                Income = drpProduct == "0" ? true : false,
                CheckDate = model.Transaction.CheckDate,
                PaymentType = model.Transaction.PaymentType == "0" ? "Kart" : (model.Transaction.PaymentType == "1" ? "Nakit" : (model.Transaction.PaymentType == "2" ? "Çek-Senet" : "")),
            };
            try
            {
                var addedAccount = _transactionService.Add(transactionForAdd);
                Guid id = addedAccount.Id;
                var till = new Till
                {
                    Id = Guid.NewGuid(),
                    AddedDate = DateTime.Now,
                    TransactionId = id,
                    AccountId = accId,
                    PaymentId = Guid.Empty,
                    Price = model.Transaction.Price,
                    CostType = acc.CostType,
                    IsTill = false,
                    IsActive = true
                };
                _tillService.Add(till);
                return Redirect("/Account/GetAccountDetail/" + accId);
            }
            catch (Exception ex)
            {
                throw new Exception("Bir hata oluştu!");
            }

            return View();
        }

        public JsonResult EditTransaction(Guid id)
        {
            if (id != null)
            {
                var result = _transactionService.GetById(id);
                return Json(result);
            }

            return Json(0);
        }

        [HttpPost]
        public IActionResult EditTransaction(TransactionViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                //var account = _accountService.GetById(accountViewModel.Transaction.AccountId);
                var transaction = _transactionService.GetById(accountViewModel.Transaction.Id);
                if (transaction == null)
                {
                    throw new Exception("An error occured!");
                }
                var transactionForUpdate = new Transaction
                {
                    Id = transaction.Id,
                    AccountId = transaction.AccountId,
                    ProductId = transaction.ProductId,
                    Text = accountViewModel.Transaction.Text,
                    Quantity = accountViewModel.Transaction.Quantity,
                    Price = accountViewModel.Transaction.Price,
                    Description = accountViewModel.Transaction.Description,
                    AddedDate = transaction.AddedDate,
                    IsActive = transaction.IsActive,
                    Income = transaction.Income,
                    CheckDate = transaction.CheckDate,
                    PaymentType = transaction.PaymentType
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
                        Price = accountViewModel.Transaction.Price,
                        CostType = tillById.CostType,
                        IsTill = tillById.IsTill,
                        IsActive = tillById.IsActive
                    };
                    _tillService.Update(till);
                    return Redirect("/Account/GetAccountDetail/" + transaction.AccountId);
                }
                catch (Exception)
                {
                    throw new Exception("An error occured!");
                }
            }
            return View();
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
                if (tillById != null)
                {
                    tillById.IsActive = false;
                    _tillService.Update(tillById);
                }
                
                return Json(1);
            }
            return Json(0);
        }

        public IActionResult IncomeTL()
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.Accounts = _accountService.GetCustomersByDate();

            return View(accountViewModel);
        }

        public IActionResult IncomeDollar()
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.Accounts = _accountService.GetCustomersByDate();

            return View(accountViewModel);
        }

        public IActionResult ExpenseTL()
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.Accounts = _accountService.GetCustomersByDate();

            return View(accountViewModel);
        }

        public IActionResult ExpenseDollar()
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.Accounts = _accountService.GetCustomersByDate();

            return View(accountViewModel);
        }

    }
}
