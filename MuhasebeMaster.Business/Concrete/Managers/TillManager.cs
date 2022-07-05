using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Concrete.Managers
{
    public class TillManager : ITillService
    {
        ITillDal _tillDal;
        public TillManager(ITillDal tillDal)
        {
            _tillDal = tillDal;
        }

        public Till Add(Till till)
        {
            return _tillDal.Add(till);
        }

        public async Task<Till> AddAsync(Till till)
        {
            return await _tillDal.AddAsync(till);
        }

        public void Delete(Till till)
        {
            _tillDal.Delete(till);
        }

        public Till GetById(Guid id)
        {
            return _tillDal.Get(d => d.Id == id);
        }

        public List<Till> GetList()
        {
            return _tillDal.GetAll();
        }

        public Till Update(Till till)
        {
            return _tillDal.Update(till);
        }

        public async Task<Till> UpdateAsync(Till till)
        {
            return await _tillDal.UpdateAsync(till);
        }
    }
}
