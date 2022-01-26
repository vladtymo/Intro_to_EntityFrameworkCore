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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public OurCompanyContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(//@"Data Source=DESKTOP-O0M8V28\SQLEXPRESS;Initial Catalog=OurCompany;Integrated Security=True;Connect Timeout=3");
                ConfigurationManager.ConnectionStrings["CompanyConnStr"].ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        // ---------- COLLECTIONS (Tables in DB) ----------
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Project> Projects { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }

        // ---------- NAVIGATION PROPERTIES ----------
        public ICollection<Worker> Workers { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]          // set as nvarchar(250)
        public string Name { get; set; }

        // ---------- NAVIGATION PROPERTIES ----------
        public ICollection<Worker> Workers { get; set; }
    }

    public class Department
    {
        [Key]                               // set as primary ket
        public int Number { get; set; }
        public string PhoneNumber { get; set; }

        // ---------- NAVIGATION PROPERTIES ----------
        public ICollection<Worker> Workers { get; set; }
    }

    // Entities
    [Table("Employees")]                    // set custom table name in db
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        // ---------- PROPERTIES (Columns in DB) ----------

        // Primary key: Id, EntityName+Id (WorkerId)
        public int Id { get; set; }

        [Column("FirstName")]               // set custom column name in db
        [Required]                          // set as not null type in db
        [MaxLength(120)]                    // set maximum length
        public string Name { get; set; }

        [Column("LastName"), Required, MaxLength(120)]
        public string Surname { get; set; }

        public decimal Salary { get; set; }
        public DateTime? Birthdate { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        // ---------- NAVIGATION PROPERTIES ----------
        // Relationship type: Zero or One to Many (0/1...*)
        public Country Country { get; set; }

        // Relationship type: One to Many (1...*)
        [Required]
        public Department Department { get; set; }

        // Relationship type: Many to Many (*...*)
        public ICollection<Project> Projects { get; set; }
    }
}
