using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_to_EF
{
    public class OurCompanyContext : DbContext
    {
        public OurCompanyContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                ConfigurationManager.ConnectionStrings["CompanyConnStr"].ConnectionString);
        }

        // Collections => Tables
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]          // set as nvarchar(250)
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    public class Department
    {
        [Key]                               // set as primary ket
        public int Number { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }

    // Entities
    [Table("Employees")]                    // set custom table name in db
    public class Worker
    {
        // Properties => Columns

        // Primary key: Id, EntityName+Id (WorkerId)
        public int Id { get; set; }

        [Column("FirstName")]               // set custom column name in db
        [Required]                          // set as not null type in db
        public string Name { get; set; }

        [Column("LastName"), Required]
        public string Surname { get; set; }

        public decimal Salary { get; set; }
        public DateTime? Birthdate { get; set; }

        // Navigation Properties
        public Country Country { get; set; }
        public Department Department { get; set; }
    }
}
