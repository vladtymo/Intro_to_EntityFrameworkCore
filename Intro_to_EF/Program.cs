using System;
using System.Configuration;
using System.Linq;

namespace Intro_to_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework!");

            OurCompanyContext context = new OurCompanyContext();

            context.Countries.Add(new Country() { Name = "Ukraine" });
            context.Countries.Add(new Country() { Name = "Italy" });
            context.Countries.Add(new Country() { Name = "Spain" });

            var dep1 = context.Departments.Add(new Department() { PhoneNumber = "54-55-66" });
            var dep2 = context.Departments.Add(new Department() { PhoneNumber = "76-66-66" });

            context.Projects.Add(new Project() { Name = "Project X", LaunchDate = DateTime.Now });
            context.Projects.Add(new Project() { Name = "Kobra", LaunchDate = new DateTime(2012, 12, 12) });

            context.SaveChanges();

            Country country = context.Countries.First();
            Department dep = context.Departments.First();
            Project proj = context.Projects.First();

            Worker worker = new Worker()
            {
                Name = "Igor",
                Surname = "Shan",
                Address = "Lublinska 43",
                Birthdate = new DateTime(1994, 4, 12),
                Salary = 3600,
                Country = country,
                Department = dep
            };
            worker.Projects.Add(proj);
            context.Workers.Add(worker);

            context.SaveChanges();

            foreach (var c in context.Countries)
            {
                Console.WriteLine(c.Name);
            }
        }
    }
}
