using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.DataAccess.Concrete;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface ITransactionDal : IEntityRepository<Transaction>
    {
        Task<List<TransactionModel>> GetTransactionsByAccount(Guid id);
    }
}
