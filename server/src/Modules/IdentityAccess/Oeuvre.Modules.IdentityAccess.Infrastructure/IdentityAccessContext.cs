using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Domaina.Infrastructure;
using Domania.Domain;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Users;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure
{
    public class IdentityAccessContext : DbContext
    {

        private IDomainEventDispatcher dispatcher;

        public DbSet<Registration> UserRegistrations { get; set; }

        public DbSet<User> Users { get; set; }

        //private readonly ILoggerFactory _loggerFactory;

        public IdentityAccessContext(DbContextOptions options
            //, IDomainEventDispatcher dispatcher
            ) : base(options)
        {
            //this.dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRegistrationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }


        //public override int SaveChanges()
        //{
        //    preSaveChanges().GetAwaiter().GetResult();
        //    var res = base.SaveChanges();
        //    return res;
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    await preSaveChanges();
        //    var res = await base.SaveChangesAsync(cancellationToken);
        //    return res;
        //}

        private async Task preSaveChanges()
        {
            await dispatchDomainEvents();
        }

        /// <summary>
        /// Domain events run within the transaction and 
        /// allow aggregates to locally communicate with eachother
        /// cleanly
        /// </summary>
        private async Task dispatchDomainEvents()
        {
            //var domainEventEntities = ChangeTracker
            //                            .Entries<Entity>()
            //                            .Select(po => po.Entity)
            //                            .Where(po => po.DomainEvents.Any())
            //                            .ToArray();

            var domainEventEntities = ChangeTracker
                                        .Entries<Entity>()
                                        .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList()
                                        .Select(x => x.Entity)
                                        .ToList(); 


            using (var scope = UserAccessCompositionRoot.BeginLifetimeScope())
            {
                dispatcher = scope.Resolve<IDomainEventDispatcher>();

                //return await mediator.Send(query);

                foreach (var entity in domainEventEntities)
                {
                    //IDomainEvent dev;
                    //while (entity.DomainEvents.TryTake(out dev))
                    //    await dispatcher.Dispatch(dev);

                    foreach (IDomainEvent events in entity.DomainEvents)
                    {
                        await dispatcher.Dispatch(events);
                    }
                }
            }

        }

    }
}
