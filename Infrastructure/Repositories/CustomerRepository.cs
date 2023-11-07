using Application.Services.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : EfRepository, ICustomerRepository
    {
        public CustomerRepository(
            CustomerDbContext context
            ) :
            base(context)
        {
        }
    }
}
