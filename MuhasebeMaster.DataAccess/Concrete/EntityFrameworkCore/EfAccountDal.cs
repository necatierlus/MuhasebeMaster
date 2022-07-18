using MuhasebeMaster.Core.DataAccess.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfAccountDal : EfEntityRepositoryBase<Account, MuhasebeMasterDbContext>, IAccountDal
    {
        public List<Account> GetCustomersByDate()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Accounts.Where(x => x.IsActive && x.AccountType == "Customer").OrderByDescending(x => x.AddedDate).ToList();
                return data;
            }
        }

        public List<Account> GetTenantsByDate()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Accounts.Where(x => x.IsActive && x.AccountType == "Tenant").OrderByDescending(x => x.AddedDate).ToList();
                return data;
            }
        }

        public List<Account> GetTrademenByDate()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Accounts.Where(x => x.IsActive && x.AccountType == "Trademen").OrderByDescending(x => x.AddedDate).ToList();
                return data;
            }
        }

    }
}
