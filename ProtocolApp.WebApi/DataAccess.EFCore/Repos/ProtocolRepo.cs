using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repos;

public class ProtocolRepo : GenericRepo<Protocol>, IProtocolRepo
{
    public ProtocolRepo(ApplicationContext context) : base(context)
    {
    }
}