using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable<User>("Users");

            builder.HasKey(x => x.id);

            builder.Property<string>("loginEmail").HasColumnName("Login");
            builder.Property<string>("password").HasColumnName("Password");
            builder.Property<bool>("isActive").HasColumnName("IsActive");
            builder.Property<string>("firstName").HasColumnName("FirstName");
            builder.Property<string>("lastName").HasColumnName("LastName");

            builder.OwnsMany<Role>("roles", b =>
            {
                b.WithOwner().HasForeignKey("RoleId");
                b.Property<string>(r => r.Name);
                b.HasKey("RoleId", "Name");

            });
        }
    }
}
