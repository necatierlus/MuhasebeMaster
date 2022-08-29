using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Abstract
{
    public interface IAccountService
    {
        Account Add(Account account);
        Task<Account> AddAsync(Account account);
        Account Update(Account account);
        Task<Account> UpdateAsync(Account account);
        void Delete(Account account);
        Account GetById(Guid id);
        List<Account> GetList();
        List<Account> GetCustomersByDate();
        List<Account> GetTenantsByDate();
        List<Account> GetTrademenByDate();
        List<Prod> GetProductsByModelNo();
        decimal GetBalance(Guid id);
    }
}
