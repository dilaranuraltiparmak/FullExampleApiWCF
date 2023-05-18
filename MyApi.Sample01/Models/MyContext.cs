using Microsoft.EntityFrameworkCore;
using MyApi.Sample01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.Models
{
    public class MyContext:DbContext
    {
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;Database=Northwind;uid=sa;pwd=123");
        }

        public DbSet<Product> Products{ get; set; }
    }
}
