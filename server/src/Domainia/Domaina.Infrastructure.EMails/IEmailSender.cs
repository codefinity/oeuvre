namespace Domaina.Infrastructure.EMails
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message);
    }
}