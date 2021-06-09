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
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBSQLServerUtils.GetDBStringConnection());
        }
    }
}
