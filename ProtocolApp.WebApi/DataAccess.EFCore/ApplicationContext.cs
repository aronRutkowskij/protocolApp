using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {
    }
    
    public DbSet<Bag> Bag { get; set; }
    public DbSet<Protocol> Protocol { get; set; }
}