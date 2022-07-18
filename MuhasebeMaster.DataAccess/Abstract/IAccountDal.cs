using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        List<Account> GetCustomersByDate();
        List<Account> GetTenantsByDate();
        List<Account> GetTrademenByDate();
    }
}
