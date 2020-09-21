using System.Threading.Tasks;

namespace Domaina.Infrastructure.EMails
{
    public interface IEmailSender
    {
        Task SendEmail(EmailMessage message);
    }
}