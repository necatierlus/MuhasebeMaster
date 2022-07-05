using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuhasebeMaster.Entity.Concrete;

namespace MuhasebeMaster.MvcWebUI.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
