using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        List<Account> GetCustomersByDate();
        List<Account> GetTenantsByDate();
        List<Account> GetTrademenByDate();
        List<Prod> GetProductsByModelNo();
        decimal GetBalance(Guid id);
        List<Till> GetTLIncome();
        List<Till> GetDollarIncome();
        List<Till> GetTLExpense();
        List<Till> GetDollarExpense();
        public decimal GetTrademenTLBalance();
        public decimal GetTrademenDollarBalance();
        public decimal GetCustomerTLBalance();
        public decimal GetCustomerDollarBalance();

    }
}
