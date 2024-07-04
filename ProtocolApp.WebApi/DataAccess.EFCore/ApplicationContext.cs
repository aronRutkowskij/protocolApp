using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {
    }
    
    public DbSet<Document> Document { get; set; }
    public DbSet<Techniker> Techniker { get; set; }
    public DbSet<Bag> Bag { get; set; }

    public void CreateDefaultRecords()
    {
        if (!Techniker.Any())
        {
            string[] names =
            {
                "Adrian Pricaz",
                "Bent Breuel",
                "Dennys Friedrichsen",
                "Enno Kauker",
                "Fabian Briedis",
                "Finn Steenbuck",
                "Fredy Castro",
                "Jona Krekeler",
                "Lasse Harms",
                "Marco Krekeler",
                "Matthias Baumann",
                "Maurice Kraemer"
            };

            for (int i = 0; i < names.Length; i++)
            {
                var t = new Techniker()
                {
                    Name = names[i],
                };
                Techniker.Add(t);
                SaveChanges();
            }
        }
    }
}







