using MuhasebeMaster.DataAccess.Concrete;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Abstract
{
    public interface ITransactionService
    {
        Transaction Add(Transaction transaction);
        Task<Transaction> AddAsync(Transaction transaction);
        Transaction Update(Transaction transaction);
        Task<Transaction> UpdateAsync(Transaction transaction);
        void Delete(Transaction transaction);
        Transaction GetById(Guid id);
        List<Transaction> GetList();
        Task<List<TransactionModel>> GetTransactionsByAccount(Guid id);
    }
}
