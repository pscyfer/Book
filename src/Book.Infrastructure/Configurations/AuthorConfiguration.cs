using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infrastructure.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(a => a.Name).HasMaxLength(60).IsRequired();

        builder.HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey("AuthorId").IsRequired(false);
    }
}
