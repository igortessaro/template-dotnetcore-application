using System.Collections.Generic;
using TemplateDotnetcoreApplication.Domain.Entities;

namespace TemplateDotnetcoreApplication.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IReadOnlyCollection<Customer> GetAll();
        bool TryConnection();
    }
}
