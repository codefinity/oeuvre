using Oeuvre.Modules.ContentCreation.Application.Configuration.Command;
using Oeuvre.Modules.ContentCreation.Domain.Articles;
using Oeuvre.Modules.IdentityAccess.IntegrationServices;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Application.CreateNewArticle
{
    public class CreateNewArticleCommandHandler : ICommandHandler<CreateNewArticleCommand, Guid>
    {
        private readonly IArticleRepository articleRepository;
        private readonly ILogger logger;

        public CreateNewArticleCommandHandler(IArticleRepository articleRepository
                                                ,ILogger logger
                                                )
        {
            this.articleRepository = articleRepository;
            this.logger = logger;
        }

        public async Task<Guid> Handle(CreateNewArticleCommand request, CancellationToken cancellationToken)
        {
            logger.Information("Register request handled");

            var permissions = await new GetUserPermissionsIntegrationService()
                                            .GetPermissions(Guid.Parse("a7d9b254-0eb7-4b0c-8b82-b0919bfb5e3a"));



            //var userRegistration = Registration.RegisterNewUser(new Guid(request.TenantId),
            //                                                        request.FirstName,
            //                                                        request.LastName,
            //                                                        password,
            //                                                        request.MobileNoCountryCode,
            //                                                        request.MobileNumber,
            //                                                        request.Email,
            //                                                        usersCounter);

            //await userRegistrationRepository.AddAsync(userRegistration);

            return Guid.NewGuid();
        }
    }
}
