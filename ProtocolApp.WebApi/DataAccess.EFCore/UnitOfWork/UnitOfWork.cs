using Domain.Interfaces;

namespace DataAccess.EFCore.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    
    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public IBagRepo Bag { get; }
    public IProtocolRepo Protocol { get; }
    
    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}