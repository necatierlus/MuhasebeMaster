using MuhasebeMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.Entity.Concrete
{
    public class Transaction : IEntity
    {

        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid ProductId { get; set; }
        public string Text {get;set;}
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Income { get; set; }
        public bool IsActive { get; set; }

 
    }
}
