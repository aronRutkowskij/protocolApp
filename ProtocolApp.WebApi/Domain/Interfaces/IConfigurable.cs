using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IConfigurable
{
    void Configure(ModelBuilder modelBuilder);
}