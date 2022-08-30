using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                var data = _context.Accounts.Where(x => x.IsActive && x.AccountType == "Müşteri").OrderByDescending(x => x.AddedDate).ToList();
                return data;
            }
        }

        public List<Account> GetTenantsByDate()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Accounts.Where(x => x.IsActive && x.AccountType == "Kiracı").OrderByDescending(x => x.AddedDate).ToList();
                return data;
            }
        }

        public List<Account> GetTrademenByDate()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Accounts.Where(x => x.IsActive && x.AccountType == "Esnaf").OrderByDescending(x => x.AddedDate).ToList();
                return data;
            }
        }

        public List<Prod> GetProductsByModelNo()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Prods.AsNoTracking().ToList();

                return data;
            }
        }

        public decimal GetBalance(Guid id)
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                decimal pos = _context.Transactions.Where(x => x.IsActive== true && x.AccountId == id && x.Income == true).Sum(x => x.Price);
                decimal neg = _context.Transactions.Where(x => x.IsActive == true && x.AccountId == id && x.Income == false).Sum(x => x.Price);
                return pos - neg;
            }
        }

        public List<Till> GetTLIncome()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Tills.Where(x => x.IsActive == true && x.Income == true && x.IsTill == false && x.CostType=="TL").OrderByDescending(x=>x.AddedDate).AsNoTracking().ToList();
                return data;
            }
        }

        public List<Till> GetDollarIncome()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Tills.Where(x => x.IsActive == true && x.Income == true && x.IsTill == false && x.CostType == "DOLAR").OrderByDescending(x => x.AddedDate).AsNoTracking().ToList();
                return data;
            }
        }

        public List<Till> GetTLExpense()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Tills.Where(x => x.IsActive == true && x.Income == false && x.IsTill == false && x.CostType == "TL").OrderByDescending(x => x.AddedDate).AsNoTracking().ToList();
                return data;
            }
        }

        public List<Till> GetDollarExpense()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var data = _context.Tills.Where(x => x.IsActive == true && x.Income == false && x.IsTill == false && x.CostType == "DOLAR").OrderByDescending(x => x.AddedDate).AsNoTracking().ToList();
                return data;
            }
        }
    }
}
