using System;
using System.Data.Entity;

namespace PracticeWinApp.Database
{
    public class DbAppContext : DbContext
    {
        public DbAppContext() : base("DBConnection")
        {
            this.Database.Log = Console.Write;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}