using System;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.Access;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Access;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure
{
    public class IdentityAccessDBContext: DbContext
    {
        //Identity
        public DbSet<User> Users { get; set; }

        //Access
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }


        public IdentityAccessDBContext(DbContextOptions options) : base(options)
        {
            //_loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            //modelBuilder.ApplyConfiguration(new UserRegistrationEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new OutboxMessageEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
        }

    }
}
