using System.Collections.Generic;
using System.Linq;
using TemplateDotnetcoreApplication.Domain.Entities;
using TemplateDotnetcoreApplication.Domain.Repositories;
using TemplateDotnetcoreApplication.Infrastructure.Repositories.Core;

namespace TemplateDotnetcoreApplication.Infrastructure.Repositories
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly TemplateDbContext _context;

        public CustomerRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Customer> GetAll()
        {
            return _context.Customers.ToList().AsReadOnly();
        }

        public bool TryConnection()
        {
            return _context.Database.CanConnect();
        }
    }
}
