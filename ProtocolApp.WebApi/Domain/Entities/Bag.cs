using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Bag : IConfigurable
{
    public long Id { get; set; }
    public string BagData { get; set; }
    public void Configure(ModelBuilder modelBuilder)
    {
        var bag = modelBuilder.Entity<Bag>()
            .HasKey(x => x.Id);
    }
}