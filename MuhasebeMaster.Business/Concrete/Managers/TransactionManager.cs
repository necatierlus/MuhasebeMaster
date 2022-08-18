using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MuhasebeMaster.Entity.Concrete;

namespace MuhasebeMaster.Business.Concrete.Managers
{
    public class TransactionManager : ITransactionService
    {
        ITransactionDal _transactionDal;
        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public Transaction Add(Transaction transaction)
        {
            return _transactionDal.Add(transaction);
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            return await _transactionDal.AddAsync(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _transactionDal.Delete(transaction);
        }

        public Transaction GetById(Guid id)
        {
            return _transactionDal.Get(d => d.Id == id);
        }

        public List<Transaction> GetList()
        {
            return _transactionDal.GetAll();
        }

        public Transaction Update(Transaction transaction)
        {
            return _transactionDal.Update(transaction);
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            return await _transactionDal.UpdateAsync(transaction);
        }

        public dynamic GetTransactionsByAccount(Guid id)
        {
            return _transactionDal.GetTransactionsByAccount(id);
        }
    }
}
