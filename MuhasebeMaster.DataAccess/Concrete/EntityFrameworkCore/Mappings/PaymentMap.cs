using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(@"Payments", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Price).HasColumnName("Price");
            builder.Property(d => d.Text).HasColumnName("Text");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
            builder.Property(d => d.CostType).HasColumnName("CostType");
            builder.Property(d => d.IsActive).HasColumnName("IsActive");
        }
    }
}
