using MuhasebeMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.Entity.Concrete
{
    public class Till : IEntity
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public Guid PaymentId { get; set; }
        public decimal Price { get; set; }
        public string CostType { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsTill { get; set; }
        public bool IsActive { get; set; }
        public bool Income { get; set; }
    }
}
