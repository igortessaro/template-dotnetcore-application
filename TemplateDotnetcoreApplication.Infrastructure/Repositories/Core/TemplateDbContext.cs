using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TemplateDotnetcoreApplication.Domain.Entities;
using TemplateDotnetcoreApplication.Infrastructure.Repositories.Mappers;

namespace TemplateDotnetcoreApplication.Infrastructure.Repositories.Core
{
    public sealed class TemplateDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public TemplateDbContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
