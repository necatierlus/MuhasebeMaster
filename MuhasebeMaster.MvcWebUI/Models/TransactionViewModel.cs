using MuhasebeMaster.DataAccess.Concrete;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuhasebeMaster.MvcWebUI.Models
{
    public class TransactionViewModel
    {
        public List<TransactionModel> TransactionModel { get; set; }

        public Account Account { get; set; }
        public List<Account> Accounts { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Prod Prod { get; set; }
        public List<Prod> Products { get; set; }
    }
}
