namespace Domain.Interfaces;

public interface IGenericRepo<T> where T : class
{
    T GetById(long? id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);
}