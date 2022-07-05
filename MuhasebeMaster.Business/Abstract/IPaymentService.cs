using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Abstract
{
    public interface IPaymentService
    {
        Payment Add(Payment Payment);
        Task<Payment> AddAsync(Payment Payment);
        Payment Update(Payment Payment);
        Task<Payment> UpdateAsync(Payment Payment);
        void Delete(Payment Payment);
        Payment GetById(Guid id);
        List<Payment> GetList();
    }
}
