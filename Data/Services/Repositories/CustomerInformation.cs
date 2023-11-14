using Data.Services.Interfaces;

namespace Data.Services.Repositories;

public class CustomerInformation : BaseRepository<Entities.CustomerInformation>, ICustomerInformation
{
    public CustomerInformation(EfCoreContext context) : base(context)
    {
    }
}