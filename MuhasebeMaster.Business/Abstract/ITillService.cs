using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Abstract
{
    public interface ITillService
    {
        Till Add(Till till);
        Task<Till> AddAsync(Till till);
        Till Update(Till till);
        Task<Till> UpdateAsync(Till till);
        void Delete(Till till);
        Till GetById(Guid id);
        List<Till> GetList();
    }
}
