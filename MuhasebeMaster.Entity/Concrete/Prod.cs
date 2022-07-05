using MuhasebeMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.Entity.Concrete
{ 
    public class Prod : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

       
    }
}
