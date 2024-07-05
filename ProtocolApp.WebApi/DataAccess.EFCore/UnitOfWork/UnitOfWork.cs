using DataAccess.EFCore.Repos;
using Domain.Interfaces;

namespace DataAccess.EFCore.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    
    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        Bag = new BagRepo(_context);
        Document = new DocumentRepo(_context);
        Techniker = new TechnikerRepo(_context);
    }

    public IBagRepo Bag { get; private set; }
    public IDocumentRepo Document { get; private set; }
    public ITechnikerRepo Techniker { get; private set; }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}