using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.API.Data.Mappings.Identity;

public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole<long>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<long>> builder)
    {
        builder.ToTable("IdentityRole");
        builder.HasKey(d => d.Id);
        builder.HasIndex(g => g.NormalizedName);
        builder.Property(d => d.ConcurrencyStamp).IsConcurrencyToken();
        builder.Property(h => h.Name).HasMaxLength(256);
        builder.Property(e => e.NormalizedName).HasMaxLength(256);
    }
}
