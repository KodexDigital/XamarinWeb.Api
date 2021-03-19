using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinWeb.Api.Models
{
    public class StudentDbContext : DbContext
    {
        //public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        //{

        //}

        //SQLLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "XamarinAPI-DB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        public DbSet<Student> Students { get; set; }
    }
}
