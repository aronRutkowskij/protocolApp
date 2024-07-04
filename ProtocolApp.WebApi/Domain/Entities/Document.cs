using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Document : IConfigurable
{
    public long Id { get; set; }
    public string Name { get; set; }
    public byte[] Data { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime? Deleted_At { get; set; }
    
    public void Configure(ModelBuilder modelBuilder)
    {
        var document = modelBuilder.Entity<Document>()
            .HasKey(x => x.Id);
    }
}