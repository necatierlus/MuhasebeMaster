using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using MuhasebeMaster.Entity.Concrete;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MuhasebeMaster.DataAccess.Identity;

namespace MuhasebeMaster.DataAccess.Concrete.EntityFrameworkCore
{
    public class MuhasebeMasterDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public MuhasebeMasterDbContext()
        {
        }
        public MuhasebeMasterDbContext(DbContextOptions<MuhasebeMasterDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string json = File.ReadAllText("appsettings.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string connectionString = jsonObj.ConnectionStrings.MuhasebeMasterDbConnection.ToString();
                optionsBuilder.UseSqlServer(connectionString);
                //optionsBuilder.UseSqlServer(@"Server=89.252.185.155\\MSSQLSERVER2017;Database=livemome_db;uid=livemome_db; pwd=X7b5x#d44;MultipleActiveResultSets=true;connect timeout=100");
                //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-7938FFHG\SQLEXPRESS;Database=MuhasebeMasterDb;integrated security=true;Connection Timeout=1800;MultipleActiveResultSets=True");
            }
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Prod> Prods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Till> Tills { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<AppIdentityUser> AppIdentityUsers { get; set; }
        public DbSet<AppIdentityRole> AppIdentityRoles { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
