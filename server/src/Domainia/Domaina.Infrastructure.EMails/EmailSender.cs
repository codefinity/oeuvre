using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Domaina.Infrastructure.EMails
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger logger;
        private readonly EmailsConfiguration configuration;

        public EmailSender(ILogger logger, EmailsConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        public async void SendEmail(EmailMessage message)
        {
            logger.Information(
                "Email sent. From: {From}, To: {To}, Subject: {Subject}, Content: {Content}.",
                configuration.RegiatrationEmailFromId,
                message.To,
                message.Subject,
                message.Content);

            try
            {

                string pickupDirectoryLocation = Environment.GetFolderPath(
                    Environment.SpecialFolder.UserProfile)
                    + "\\"+ configuration.PickupDirectoryLocation;

                var client = new SmtpClient() { DeliveryMethod = (SmtpDeliveryMethod)Enum.Parse(typeof(SmtpDeliveryMethod), configuration.DeliveryMethod),
                                                PickupDirectoryLocation = pickupDirectoryLocation
                };

                //Will run only in dev environment
                DevEnvironametHelpers.InDevEnvCreateTestMailFolderIfNotExists(client.PickupDirectoryLocation);

                client.SendAsync(configuration.RegiatrationEmailFromId,
                                        message.To, 
                                        message.Subject, 
                                        message.Content,
                                        null);
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}