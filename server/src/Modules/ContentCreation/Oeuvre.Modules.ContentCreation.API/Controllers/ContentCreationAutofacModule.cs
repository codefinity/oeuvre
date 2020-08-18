using Autofac;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using Oeuvre.Modules.ContentCreation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.API.Controllers
{
    public class ContentCreationAutofacModule  : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentCreationModule>()
                                .As<IContentCreationModule>()
                                .InstancePerLifetimeScope();
        }

    }
}
