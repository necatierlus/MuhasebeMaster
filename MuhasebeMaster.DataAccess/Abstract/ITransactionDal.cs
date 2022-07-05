using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface ITransactionDal : IEntityRepository<Transaction>
    {
    }
}
