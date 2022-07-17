using Microsoft.EntityFrameworkCore;
using MuhasebeMaster.Core.DataAccess.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.ComplexTypes;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProdDal : EfEntityRepositoryBase<Prod, MuhasebeMasterDbContext>, IProdDal
    {
        public List<Prod> GetProductByDate()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var prod = _context.Prods.OrderByDescending(x => x.AddedDate).ToList();
                return prod;
            }
        }
    }
}
