using MuhasebeMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.Entity.Concrete
{
    public class Payment : IEntity
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Text {get;set;}
        public DateTime AddedDate { get; set; }
        public string CostType { get; set; }
        public bool IsActive { get; set; }

    
}
}
