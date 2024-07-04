using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repos;

public class DocumentRepo : GenericRepo<Document>, IDocumentRepo
{
    public DocumentRepo(ApplicationContext context) : base(context)
    {
    }
}