using AlternativeEngineerBlogServer.Domain.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder
            .Property(p => p.ContactName)
            .IsRequired()
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder
            .Property(p => p.ContactEmail)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder
            .Property(p => p.Subject)
            .IsRequired()
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);

        builder
            .Property(p => p.Content)
            .IsRequired()
            .HasColumnType("varchar(MAX)")
            .HasMaxLength(1000);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
