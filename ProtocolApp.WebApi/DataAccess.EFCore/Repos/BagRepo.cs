using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repos;

public class BagRepo : GenericRepo<Bag>, IBagRepo
{
    public BagRepo(ApplicationContext context) : base(context)
    {
    }
}