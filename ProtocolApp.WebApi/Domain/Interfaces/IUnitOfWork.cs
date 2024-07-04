namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDocumentRepo Document { get; }
    IBagRepo Bag { get; }
    ITechnikerRepo Techniker { get; }
    Task<int> Complete();
}