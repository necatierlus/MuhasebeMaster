using Microsoft.EntityFrameworkCore;
using MuhasebeMaster.Core.DataAccess.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfTransactionDal : EfEntityRepositoryBase<Transaction, MuhasebeMasterDbContext>, ITransactionDal
    {
        public async Task<List<TransactionModel>> GetTransactionsByAccount(Guid id)
        {
            List<TransactionModel> transactionModels = new List<TransactionModel>();
            using (var _context = new MuhasebeMasterDbContext())
            {
                List<Transaction> tran = null;
                tran = await  _context.Transactions.Where(x => x.AccountId == id && x.IsActive==true).OrderByDescending(x => x.AddedDate).ToListAsync();
                foreach (var item in tran)
                {
                    TransactionModel model = new TransactionModel()
                    {
                        Id = item.Id,
                        ProductName = item.ProductId.ToString(),
                        Description = item.Description,
                        AddedDate = item.AddedDate,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        PaymentType = item.PaymentType,
                        CheckDate = item.CheckDate,
                        Text = item.Text,
                        Income = item.Income
                    };
                    transactionModels.Add(model);
                }
                return transactionModels;
            }
        }
    }
}
