using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TemplateDotnetcoreApplication.Domain.Entities;

namespace TemplateDotnetcoreApplication.Infrastructure.Repositories.Mappers
{
    public sealed class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(entity => entity.Id).HasColumnName("id");
            builder.Property(entity => entity.FirstName).HasColumnName("first_name");
            builder.Property(entity => entity.LastName).HasColumnName("last_name");

            builder.ToTable(nameof(Customer), "dbo");
        }
    }
}
