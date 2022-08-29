using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.DataAccess.Concrete;
using MuhasebeMaster.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeMaster.MvcWebUI.ViewComponents
{
    public class Transaction : ViewComponent
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        public Transaction(IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            TransactionViewModel model = new TransactionViewModel();
            model.TransactionModel = new List<TransactionModel>();
            Guid id = Guid.Parse(HttpContext.Session.GetString("AccountId"));
            var tran = await  _transactionService.GetTransactionsByAccount(id);
            if (tran != null)
            {
                model.TransactionModel = tran;
                return View(model);
            }
            return View(model);
        }
    }
}
