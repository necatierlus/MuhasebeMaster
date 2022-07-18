using MuhasebeMaster.Entity.Concrete;
using System.Collections.Generic;

namespace MuhasebeMaster.MvcWebUI.Models
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
