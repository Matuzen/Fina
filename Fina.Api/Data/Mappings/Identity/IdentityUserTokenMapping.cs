using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.API.Data.Mappings.Identity;

public class IdentityUserTokenMapping : IEntityTypeConfiguration<IdentityUserToken<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<long>> builder)
    {
        builder.ToTable("IdentityUserToken");
        builder.HasKey(f => new { f.UserId, f.LoginProvider, f.Name });
        builder.Property(y => y.LoginProvider).HasMaxLength(120);
        builder.Property(a => a.Name).HasMaxLength(180);
    }
}
