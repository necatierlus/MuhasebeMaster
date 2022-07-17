using MuhasebeMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.Entity.Concrete
{
    public class Account : IEntity
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string AccountType { get; set; }
        public string CostType { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
