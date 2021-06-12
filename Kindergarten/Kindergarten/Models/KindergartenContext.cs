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

        }
    }
}
