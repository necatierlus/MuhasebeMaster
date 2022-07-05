using MuhasebeMaster.Core.DataAccess;
using MuhasebeMaster.Entity.ComplexTypes;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Abstract
{
    public interface IProdDal : IEntityRepository<Prod> 
    {
    }
}
