using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public interface IPasswordResetRequestRepository
    {
        Task AddAsync(PasswordResetRequest passwordResetRequest);

        Task UpdateAsync(PasswordResetRequest passwordResetRequest);

        Task<PasswordResetRequest> GetByIdAsync(PasswordResetRequestId passwordResetRequest);
    }
}
