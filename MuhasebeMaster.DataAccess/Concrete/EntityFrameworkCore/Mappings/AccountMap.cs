using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(@"Accounts", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Fullname).HasColumnName("Fullname");
            builder.Property(d => d.Phone).HasColumnName("Phone");
            builder.Property(d => d.City).HasColumnName("City");
            builder.Property(d => d.Address).HasColumnName("Address");
            builder.Property(d => d.AccountType).HasColumnName("AccountType");
            builder.Property(d => d.CostType).HasColumnName("CostType");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
            builder.Property(d => d.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
