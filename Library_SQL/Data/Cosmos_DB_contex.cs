using Library_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_SQL.Data
{
   public class Cosmos_DB_contex : DbContext
    {
        public DbSet<Customer> Customers { get; set; }//från models

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//conect till DB Cosmos
        {
            optionsBuilder.UseCosmos("enpointUri", "PrimaryKey", databaseName: "CosmosDB");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//model creation conteiner
        {
            modelBuilder.HasDefaultContainer("Customers").Entity<Customer>().HasNoDiscriminator();
            base.OnModelCreating(modelBuilder);
        }
    }
}
