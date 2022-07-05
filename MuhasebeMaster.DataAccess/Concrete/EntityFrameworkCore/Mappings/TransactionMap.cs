using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Transaction = MuhasebeMaster.Entity.Concrete.Transaction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(@"Transactions", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.AccountId).HasColumnName("AccountId");
            builder.Property(d => d.ProductId).HasColumnName("ProductId");
            builder.Property(d => d.Text).HasColumnName("Text");
            builder.Property(d => d.Quantity).HasColumnName("Quantity");
            builder.Property(d => d.Price).HasColumnName("Price");
            builder.Property(d => d.Description).HasColumnName("Description");
            builder.Property(d => d.Income).HasColumnName("Income");
            builder.Property(d => d.IsActive).HasColumnName("IsActive");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
        }
    }
}
