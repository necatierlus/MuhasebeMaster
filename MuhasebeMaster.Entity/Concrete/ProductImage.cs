using System;
using System.Collections.Generic;
using System.Text;
using MuhasebeMaster.Core.Entities;

namespace MuhasebeMaster.Entity.Concrete
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
