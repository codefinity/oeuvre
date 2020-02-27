using System;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure
{
    public class IdentityAccessContext: DbContext
    {
        public DbSet<User> Users { get; set; }


        public IdentityAccessContext(DbContextOptions options) : base(options)
        {
            //_loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //modelBuilder.ApplyConfiguration(new UserRegistrationEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new OutboxMessageEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new InternalCommandEntityTypeConfiguration());
        }

    }
}
