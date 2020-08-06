using System;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure
{
    public class UserAccessContext : DbContext
    {
        public DbSet<Registration> UserRegistrations { get; set; }
        //public DbSet<User> Users { get; set; }

        //public DbSet<OutboxMessage> OutboxMessages { get; set; }

        //public DbSet<InternalCommand> InternalCommands { get; set; }

        // private readonly ILoggerFactory _loggerFactory;

        public UserAccessContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRegistrationEntityTypeConfiguration());
        }

    }
}
