using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.ContentCreation.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Members
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly ContentCreationContext contentCreationContext;

        internal MemberRepository(ContentCreationContext contentCreationContext)
        {
            this.contentCreationContext = contentCreationContext;
        }

        public async Task AddAsync(Member member)
        {
            await contentCreationContext.Members.AddAsync(member);
        }

        public async Task<Member> GetByIdAsync(MemberId memberId)
        {
            return await contentCreationContext.Members.FirstOrDefaultAsync(x => x.Id == memberId);
        }
    }
}
