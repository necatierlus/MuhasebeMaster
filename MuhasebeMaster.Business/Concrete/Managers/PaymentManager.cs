using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Concrete.Managers
{
    public class PaymentManager : IPaymentService
    {

        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public Payment Add(Payment Payment)
        {
            return _paymentDal.Add(Payment);
        }

        public async Task<Payment> AddAsync(Payment Payment)
        {
            return await _paymentDal.AddAsync(Payment);
        }

        public void Delete(Payment Payment)
        {
            _paymentDal.Delete(Payment);
        }

        public Payment GetById(Guid id)
        {
            return _paymentDal.Get(d => d.Id == id);
        }

        public List<Payment> GetList()
        {
            return _paymentDal.GetAll();
        }

        public Payment Update(Payment Payment)
        {
            return _paymentDal.Update(Payment);
        }

        public async Task<Payment> UpdateAsync(Payment Payment)
        {
            return await _paymentDal.UpdateAsync(Payment);
        }
    }
}
