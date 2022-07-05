using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Concrete.Managers
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
        public Account Add(Account account)
        {
            return _accountDal.Add(account);
        }

        public async Task<Account> AddAsync(Account account)
        {
            return await _accountDal.AddAsync(account);
        }

        public void Delete(Account account)
        {
            _accountDal.Delete(account);
        }

        public Account GetById(Guid id)
        {
            return _accountDal.Get(d => d.Id == id);
        }

        public List<Account> GetList()
        {
            return _accountDal.GetAll();
        }

        public Account Update(Account account)
        {
            return _accountDal.Update(account);
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            return await _accountDal.UpdateAsync(account);
        }
    }
}
