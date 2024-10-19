using AlternativeEngineerBlogServer.Domain.EmailJsParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlternativeEngineerBlogServer.Infrastructure.Configurations;
public sealed class EmailJsParameterConfiguration : IEntityTypeConfiguration<EmailJsParameter>
{
    public void Configure(EntityTypeBuilder<EmailJsParameter> builder)
    {
        builder
           .Property(p => p.Name).HasColumnType("varchar(50)").HasMaxLength(50);
        builder
           .Property(p => p.ServiceId).HasColumnType("varchar(50)").HasMaxLength(50);
        builder
           .Property(p => p.TemplateId).HasColumnType("varchar(50)").HasMaxLength(50);
        builder
           .Property(p => p.PublicKey).HasColumnType("varchar(50)").HasMaxLength(50);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
