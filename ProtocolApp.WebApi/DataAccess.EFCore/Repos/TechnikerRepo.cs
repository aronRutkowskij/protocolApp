using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repos;

public class TechnikerRepo : GenericRepo<Techniker>, ITechnikerRepo
{
    public TechnikerRepo(ApplicationContext context) : base(context)
    {
    }
}