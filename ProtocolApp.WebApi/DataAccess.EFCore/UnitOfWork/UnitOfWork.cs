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
    public IDocumentRepo Document { get; }
    public ITechnikerRepo Techniker { get; }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}