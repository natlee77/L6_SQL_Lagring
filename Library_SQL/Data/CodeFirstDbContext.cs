
using Library_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_SQL.Data // steg 2- after installed Entity, sql server, tools, design
{
    class SQL_CodeFirstContext : DbContext
    {
        //i vissa fal ctor:
        //public CodeFirstDbContext(DbSet<Customer> customers)
        //{
        //    Customers = customers;
        //}



        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\46735\Documents\CodeFirst_DB.mdf;Integrated Security=True;Connect Timeout=30");// local connect string
            base.OnConfiguring(optionsBuilder);
        }
    }
}// steg 3. göra migration  PM>
