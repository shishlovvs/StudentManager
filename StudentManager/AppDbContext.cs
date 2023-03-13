using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using System.Diagnostics.Eventing.Reader;

namespace StudentManager
{
    internal class AppDbContext : DbContext
    {
        private const string ConnectionString = "Data Source = hello.db";
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }

        public DbSet<Student> Students => Set<Student>();
    }

    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
