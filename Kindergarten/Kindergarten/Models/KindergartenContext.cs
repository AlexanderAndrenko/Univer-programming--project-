using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.Models
{
    class KindergartenContext :DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishItem> DishItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DishFact> DishFacts { get; set; }
        public DbSet<DishItemFact> DishItemFacts { get; set; }
        public DbSet<MenuFact> MenuFacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentData> DocumentData { get; set; }
        public DbSet<NumberChildren> NumberChildrens { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public KindergartenContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBSQLServerUtils.GetDBStringConnection());            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Значения поля IsClosed у партии по умолчанию 0
            modelBuilder.Entity<Party>().Property(u => u.IsClosed).HasDefaultValue(0);

            //Значения поля IsDeleted у партии по умолчанию 0
            modelBuilder.Entity<Party>().Property(u => u.IsDeleted).HasDefaultValue(0);

            //Значение уровня доступа у пользователя по умолчанию 0
            modelBuilder.Entity<User>().Property(u => u.LevelAccess).HasDefaultValue(0);
        }
    }
}
