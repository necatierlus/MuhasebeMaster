using MuhasebeMaster.Core.DataAccess.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfTillDal : EfEntityRepositoryBase<Till, MuhasebeMasterDbContext>, ITillDal
    {
        public decimal GetTillTLBalance()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var pos = _context.Tills.Where(x => x.IsTill == false && x.IsActive && x.CostType == "TL" && x.Income).Sum(x => x.Price);
                var neg = _context.Tills.Where(x => x.IsTill == false && x.IsActive && x.CostType == "TL" && !x.Income).Sum(x => x.Price);
                return pos - neg;
            }
        }

        public decimal GetTillDollarBalance()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var pos = _context.Tills.Where(x => x.IsTill == false && x.IsActive  && x.CostType == "DOLAR" && x.Income).Sum(x => x.Price);
                var neg = _context.Tills.Where(x => x.IsTill == false && x.IsActive && x.CostType == "DOLAR" && !x.Income).Sum(x => x.Price);
                return pos - neg;
            }
        }

        public Till GetByTransaction(Guid id)
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var total = _context.Tills.Where(x => x.TransactionId == id && x.IsActive).FirstOrDefault();
                return total;
            }
        }
    }
}
