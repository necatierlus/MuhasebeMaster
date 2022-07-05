using MuhasebeMaster.Business.Abstract;
using MuhasebeMaster.DataAccess.Abstract;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuhasebeMaster.Business.Concrete.Managers
{
   public class ProdManager : IProdService
    {
        IProdDal _prodDal;
        public ProdManager(IProdDal prodDal)
        {
            _prodDal = prodDal;
        }
        public Prod Add(Prod prod)
        {
            return _prodDal.Add(prod);
        }

        public async Task<Prod> AddAsync(Prod prod)
        {
            return await _prodDal.AddAsync(prod);
        }

        public void Delete(Prod prod)
        {
            _prodDal.Delete(prod);
        }

        public Prod GetById(Guid id)
        {
            return _prodDal.Get(d => d.Id == id);
        }

        public List<Prod> GetList()
        {
            return _prodDal.GetAll();
        }

        public Prod Update(Prod prod)
        {
            return _prodDal.Update(prod);
        }

        public async Task<Prod> UpdateAsync(Prod prod)
        {
            return await _prodDal.UpdateAsync(prod);
        }
    }
}
