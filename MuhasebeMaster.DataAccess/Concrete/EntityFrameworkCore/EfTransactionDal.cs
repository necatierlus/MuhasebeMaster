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
    public class EfTransactionDal : EfEntityRepositoryBase<Transaction, MuhasebeMasterDbContext>, ITransactionDal
    {
        public dynamic GetTransactionsByAccount(Guid id)
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                //var tran = _context.Transactions.Where(x => x.AccountId == id && x.IsActive ).OrderByDescending(x => x.AddedDate).AsNoTracking().ToList();
                var tran = from p in _context.Transactions
                           where p.AccountId == id && p.IsActive == true
                           orderby p.AddedDate descending
                           select new
                           {
                               p.Text,
                               p.Description,
                               p.Quantity,
                               p.Price,
                               p.AddedDate
                           };

                return tran.AsNoTracking().ToList();
            }
        }
    }
}
