using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CustomerInformation : BaseRepository<Entities.CustomerInformation>, ICustomerInformation
{
    public CustomerInformation(EfCoreContext context) : base(context)
    {
    }
}