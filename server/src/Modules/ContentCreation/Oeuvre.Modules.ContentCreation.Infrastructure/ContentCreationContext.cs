using Autofac;
using Domaina.Infrastructure;
using Domania.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oeuvre.Modules.ContentCreation.Domain.Articles;
using Oeuvre.Modules.ContentCreation.Domain.Collaborators;
using Oeuvre.Modules.ContentCreation.Domain.Members;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration;
using Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Articles;
using Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Collaborators;
using Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure
{
    public class ContentCreationContext : DbContext
    {

        private IDomainEventDispatcher dispatcher;

        public DbSet<Article> Articles { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Member> Members { get; set; }

        private readonly ILoggerFactory loggerFactory;
        public ContentCreationContext(DbContextOptions options
                                        , ILoggerFactory loggerFactory
                                        //, IDomainEventDispatcher dispatcher
                                        ) : base(options)
        {
            this.loggerFactory = loggerFactory;
            //this.dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CollaboratorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());

        }

        public override int SaveChanges()
        {
            ApplyFixForUpdatingOwnedEntities().GetAwaiter().GetResult(); ;

            int result = base.SaveChanges();

            //Apply try catch here so that domain events are sent after successful save.
            DispatchDomainEvents().GetAwaiter().GetResult();

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await ApplyFixForUpdatingOwnedEntities();

            int result = await base.SaveChangesAsync(cancellationToken);

            //Apply try catch here so that domain events are sent after successful save.
            await DispatchDomainEvents();

            return result;
        }

        /// <summary>
        /// Domain events run within the transaction and 
        /// allow aggregates to locally communicate with eachother
        /// cleanly
        /// </summary>
        private async Task DispatchDomainEvents()
        {
            //Original statement - Kept for reference.
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


            using (var scope = ContentCreationCompositionRoot.BeginLifetimeScope())
            {
                dispatcher = scope.Resolve<IDomainEventDispatcher>();

                foreach (var entity in domainEventEntities)
                {
                    foreach (IDomainEvent events in entity.DomainEvents)
                    {
                        await dispatcher.Dispatch(events);
                    }
                }
            }

        }

        public Task ApplyFixForUpdatingOwnedEntities()
        {
            var ownedEntities = ChangeTracker.Entries<ValueObject>().Where(x => x.State == EntityState.Added
                                                                                || x.State == EntityState.Deleted
                                                                                //Just added for testing
                                                                                //|| x.State == EntityState.Modified
                                                                                )
                                                                            .ToList();

            foreach (var ownedEntityEntry in ownedEntities)
            {
                var ownership = ownedEntityEntry.Metadata.FindOwnership();
                if (ownership != null)
                {
                    var parentKey = ownership.Properties.Select(p => ownedEntityEntry.Property(p.Name).CurrentValue).ToArray();
                    var parent = Find(ownership.PrincipalEntityType.ClrType, parentKey);
                    if (parent != null)
                    {
                        var parentEntry = Entry(parent);
                        if (ownedEntityEntry.State == EntityState.Deleted && parentEntry.State != EntityState.Deleted)
                        {
                            parentEntry.State = EntityState.Modified;
                            var navProperty = ownership.PrincipalToDependent.FieldInfo;
                            if (navProperty.GetValue(parentEntry.Entity) == null)
                                navProperty.SetValue(parentEntry.Entity, FormatterServices.GetUninitializedObject(ownedEntityEntry.Metadata.ClrType));
                        }
                        else if (ownedEntityEntry.State == EntityState.Added && parentEntry.State == EntityState.Modified)
                        {
                            string doNothing = "Do Nothing";
                        }
                        else if (ownedEntityEntry.State == EntityState.Deleted && parentEntry.State == EntityState.Modified)
                        {
                            string doNothingStill = "Still, Do Nothing";
                        }
                        else if (ownedEntityEntry.State == EntityState.Added && parentEntry.State != EntityState.Added)
                        {
                            ownedEntityEntry.State = EntityState.Modified;
                        }
                        //Added to Update the Collection Value Object - not working due to conflict with simple add.
                        //Conflict resolved in above code.
                        //else if (ownedEntityEntry.State == EntityState.Added && parentEntry.State == EntityState.Added)
                        //{
                        //ownedEntityEntry.State = EntityState.Added;
                        ////parentEntry.State = EntityState.Modified;
                        //}
                    }
                }
            }

            return Task.CompletedTask;

        }

    }
}
