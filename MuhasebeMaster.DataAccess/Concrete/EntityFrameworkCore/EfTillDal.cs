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
                var total = _context.Tills.Where(x => x.IsTill == true && x.IsActive && x.CostType == "TL").Sum(x => x.Price);
                return total;
            }
        }

        public decimal GetTillDollarBalance()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var total = _context.Tills.Where(x => x.IsTill == true && x.IsActive  && x.CostType == "DOLAR").Sum(x => x.Price);
                return total;
            }
        }

        public Till GetByTransaction(Guid id)
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var total = _context.Tills.Where(x => x.TransactionId == id).FirstOrDefault();
                return total;
            }
        }
    }
}
