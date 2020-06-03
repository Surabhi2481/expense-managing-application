using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExpenseManagingSystem.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name = DbContextConn")
        {

        }
        public DbSet<mainClass> mainClasss { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }

}