using Fina.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mappings.Identity;

public class IdentityUserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> user)
    {
        user.ToTable("IdentityUser");
        user.HasKey(z => z.Id);

        user.HasIndex(z => z.NormalizedUserName).IsUnique();
        user.HasIndex(z => z.NormalizedEmail).IsUnique();

        user.Property(z => z.Email).HasMaxLength(180);
        user.Property(z => z.NormalizedEmail).HasMaxLength(180);
        user.Property(z => z.UserName).HasMaxLength(180).IsRequired();
        user.Property(z => z.NormalizedUserName).HasMaxLength(180);
        user.Property(z => z.PhoneNumber).HasMaxLength(20);
        user.Property(z => z.ConcurrencyStamp).IsConcurrencyToken();

        user.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(z => z.UserId).IsRequired();
        user.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(z => z.UserId).IsRequired();
        user.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(z => z.UserId).IsRequired();
        user.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(z => z.UserId).IsRequired();
    }
}
