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
    }
}







