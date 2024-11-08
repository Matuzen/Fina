using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.API.Data.Mappings.Identity;

public class IdenitityRoleClaimMapping : IEntityTypeConfiguration<IdentityRoleClaim<long>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<long>> builder)
    {
        builder.ToTable("IdentityRoleClaim");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.ClaimType).HasMaxLength(255);
        builder.Property(h => h.ClaimValue).HasMaxLength(255);

    }
}
