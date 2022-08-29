using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime CheckDate { get; set; }
        public string PaymentType { get; set; }
        public bool Income { get; set; }
    }
}
