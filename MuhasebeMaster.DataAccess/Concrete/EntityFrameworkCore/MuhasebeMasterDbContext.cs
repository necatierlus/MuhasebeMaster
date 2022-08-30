using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using MuhasebeMaster.Entity.Concrete;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class MuhasebeMasterDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("MuhasebeMasterDbConnection");
            optionsBuilder.UseSqlServer(@"Data Source=89.252.185.155\\MSSQLSERVER2017;Initial Catalog=livemome_db;User Id=livemome_db;Password=X7b5x#d44;");
            //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-7938FFHG\SQLEXPRESS;Database=MuhasebeMasterDb;integrated security=true;Connection Timeout=1800;MultipleActiveResultSets=True");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Prod> Prods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Till> Tills { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Account>(new AccountMap());
            modelBuilder.ApplyConfiguration<Prod>(new ProdMap());
            modelBuilder.ApplyConfiguration<Payment>(new PaymentMap());
            modelBuilder.ApplyConfiguration<Till>(new TillMap());
            modelBuilder.ApplyConfiguration<Transaction>(new TransactionMap());
            modelBuilder.ApplyConfiguration<Category>(new CategoryMap());
            modelBuilder.ApplyConfiguration<Product>(new ProductMap());
            modelBuilder.ApplyConfiguration<ProductImage>(new ProductImageMap());
        }
    }
}
