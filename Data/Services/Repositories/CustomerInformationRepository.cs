using Data.Entities;
using Data.Services.Interfaces;

namespace Data.Services.Repositories;

public class CustomerInformationRepositoryRepository : BaseRepository<CustomerInformation>,
    ICustomerInformationRepository
{
    public CustomerInformationRepositoryRepository(EfCoreContext context) : base(context)
    {
    }
}