using System;
using System.Collections.Generic;
using System.Text;
using MuhasebeMaster.Core.DataAccess.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage,MuhasebeMasterDbContext>,IProductImageDal
    {
    }
}
