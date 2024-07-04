using Domain.Interfaces;

namespace DataAccess.EFCore.Repos;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    protected readonly ApplicationContext _context;

    public GenericRepo(ApplicationContext context)
    {
        _context = context;
    }
    
    public T GetById(long? id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}