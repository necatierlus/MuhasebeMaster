using System;
using System.Collections.Generic;
using System.Text;
using MuhasebeMaster.Core.DataAccess.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.ComplexTypes;
using MuhasebeMaster.Entity.Concrete;
using System.Linq;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProductDal : EfEntityRepositoryBase<Product, MuhasebeMasterDbContext>, IProductDal
    {
        public List<ProductCategoryComplexData> GetProductWithCategory()
        {
            using (var _context = new MuhasebeMasterDbContext())
            {
                var result = from p in _context.Products
                             join c in _context.Categories on p.CategoryId equals c.Id
                             select new ProductCategoryComplexData
                             {
                                 CategoryName = c.Name,
                                 Height = p.Height,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 Weight = p.Weight,
                                 Width = p.Width
                             };
                return result.ToList();
            }
        }
    }
}
