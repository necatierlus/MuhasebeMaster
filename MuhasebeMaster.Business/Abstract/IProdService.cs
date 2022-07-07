using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Abstract
{
    public interface IProdService
    {
        Prod Add(Prod prod);
        Task<Prod> AddAsync(Prod prod);
        Prod Update(Prod prod);
        Task<Prod> UpdateAsync(Prod prod);
        void Delete(Prod prod);
        Prod GetById(Guid id);
        List<Prod> GetList();
        Task<List<Prod>> GetProductWithDate();
        Prod GetByName(string name);
    }
}
