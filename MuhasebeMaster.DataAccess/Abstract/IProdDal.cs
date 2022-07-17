using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.Entity.ComplexTypes;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface IProdDal : IEntityRepository<Prod> 
    {
        List<Prod> GetProductByDate();
    }
}
