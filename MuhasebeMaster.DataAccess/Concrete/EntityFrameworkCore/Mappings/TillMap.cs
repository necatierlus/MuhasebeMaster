using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class TillMap : IEntityTypeConfiguration<Till>
    {
        public void Configure(EntityTypeBuilder<Till> builder)
        {
            builder.ToTable(@"Tills", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.TransactionId).HasColumnName("TransactionId");
            builder.Property(d => d.AccountId).HasColumnName("AccountId");
            builder.Property(d => d.PaymentId).HasColumnName("PaymentId");
            builder.Property(d => d.Price).HasColumnName("Price");
            builder.Property(d => d.CostType).HasColumnName("CostType");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
            builder.Property(d => d.IsTill).HasColumnName("Till");
            builder.Property(d => d.IsActive).HasColumnName("IsActive");
        }
    }
}
