using System;

namespace Intro_to_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework!");

            OurCompanyContext context = new OurCompanyContext();

            //context.Countries.Add(new Country() { Name = "Ukraine" });
            //context.Countries.Add(new Country() { Name = "Italy" });
            //context.Countries.Add(new Country() { Name = "Spain" });

            //context.SaveChanges();

            foreach (var c in context.Countries)
            {
                Console.WriteLine(c.Name);
            }
        }
    }
}
