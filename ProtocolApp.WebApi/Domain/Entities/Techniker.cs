using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Techniker : IConfigurable
{
    public long Id { get; set; }
    public string Name { get; set; }
    public void Configure(ModelBuilder modelBuilder)
    {
        var techniker = modelBuilder.Entity<Techniker>()
            .HasKey(x => x.Id);
    }
}