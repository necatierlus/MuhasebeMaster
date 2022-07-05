using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhasebeMaster.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class ProdMap : IEntityTypeConfiguration<Prod>
    {
        public void Configure(EntityTypeBuilder<Prod> builder)
        {
            builder.ToTable(@"Products", @"dbo");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name).HasColumnName("Name");
            builder.Property(d => d.Model).HasColumnName("Model");
            builder.Property(d => d.Description).HasColumnName("Description");
            builder.Property(d => d.Quantity).HasColumnName("Quantity");
            builder.Property(d => d.UnitPrice).HasColumnName("UnitPrice");
            builder.Property(d => d.TotalPrice).HasColumnName("TotalPrice");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
            builder.Property(d => d.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
