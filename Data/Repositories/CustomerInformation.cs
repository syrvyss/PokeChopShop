using Data.Entities;

namespace Data.Repositories;

public class CustomerInformation : BaseRepository<Entities.CustomerInformation>, ICustomerInformation
{
    public CustomerInformation(EfCoreContext context) : base(context)
    {
    }
}