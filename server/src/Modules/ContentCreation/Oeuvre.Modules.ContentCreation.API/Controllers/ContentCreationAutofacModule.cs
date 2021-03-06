﻿using Autofac;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using Oeuvre.Modules.ContentCreation.Infrastructure;

namespace Oeuvre.Modules.ContentCreation.API.Controllers
{
    public class ContentCreationAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentCreationModule>()
                                .As<IContentCreationModule>()
                                .InstancePerLifetimeScope();
        }

    }
}
