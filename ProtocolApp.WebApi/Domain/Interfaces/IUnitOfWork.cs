namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBagRepo Bag { get; }
    IProtocolRepo Protocol { get; }
    Task<int> Complete();
}