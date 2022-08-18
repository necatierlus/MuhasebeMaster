using Microsoft.AspNetCore.Mvc.Rendering;
using MuhasebeMaster.Entity.Concrete;
using System.Collections.Generic;

namespace MuhasebeMaster.MvcWebUI.Models
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public List<Account> Accounts { get; set; }
        public List<SelectListItem> AccountTypes { get; set; }
        public List<SelectListItem> CostTypes { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Product Product { get; set; }
    }
}
