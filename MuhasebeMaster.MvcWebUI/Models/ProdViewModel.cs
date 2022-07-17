using MuhasebeMaster.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhasebeMaster.MvcWebUI.Models
{
    public class ProdViewModel
    {
        public Prod Product{ get; set; }
        public List<Prod> Products { get; set; }
    }
}
