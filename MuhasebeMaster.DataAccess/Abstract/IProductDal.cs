using System;
using System.Collections.Generic;
using System.Text;
using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.Entity.ComplexTypes;
using MuhasebeMaster.Entity.Concrete;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductCategoryComplexData> GetProductWithCategory();
    }
}
