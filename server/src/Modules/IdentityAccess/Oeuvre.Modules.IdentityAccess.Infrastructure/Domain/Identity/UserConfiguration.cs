using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.UserId);
            //builder.OwnsOne(x => x.Price, p => p.OwnsOne(c => c.Currency));
            builder.Property<string>("loginEmail").HasColumnName("Login");
            builder.Property<string>("password").HasColumnName("Password");
            builder.Property<bool>("isActive").HasColumnName("IsActive");

            builder.OwnsMany<UserRole>("userroles", b =>
            {
                b.ToTable("UserRoles");
                b.WithOwner().HasForeignKey("UserId");
                //b.Property<UserId>("UserId");
                b.Property<string>(r => r.Code);
                b.HasKey("UserId", "Code");


                //b.ToTable("Roles", "users");
                //b.Property<UserId>("UserId");
                //b.Property<string>("Name").HasColumnName("Name");
                //b.WithOwner().HasForeignKey("UserId");
                //b.HasKey("UserId", "Name");

            });
        }

        //public void Configure(EntityTypeBuilder<User> builder)
        //{
        //    builder.ToTable("Users", "users");

        //    builder.HasKey(x => x.UserId);

        //    builder.Property<string>("loginEmail").HasColumnName("Login");
        //    builder.Property<string>("password").HasColumnName("Password");
        //    builder.Property<bool>("isActive").HasColumnName("IsActive");
        //    //builder.Property<string>("firstName").HasColumnName("FirstName");
        //    //builder.Property<string>("lastName").HasColumnName("LastName")

        //    //builder.OwnsMany<Role>("roles", b =>
        //    //{
        //        //b.WithOwner().HasForeignKey("UserId");
        //        //b.Property<UserId>("UserId");
        //        //b.Property<string>(r => r.Name);
        //        //b.HasKey("UserId", "Name");


        //        //b.ToTable("Roles", "users");
        //        //b.Property<UserId>("UserId");
        //        //b.Property<string>("Name").HasColumnName("Name");
        //        //b.WithOwner().HasForeignKey("UserId");
        //        //b.HasKey("UserId", "Name");



        //    //});
        //}
    }
}
