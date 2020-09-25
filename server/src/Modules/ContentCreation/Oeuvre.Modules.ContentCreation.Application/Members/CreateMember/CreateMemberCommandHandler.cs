using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Domaina.CQRS.Command;
using MediatR;
using Oeuvre.Modules.ContentCreation.Domain.Members;

namespace Oeuvre.Modules.ContentCreation.Application.Members.CreateMember
{
    internal class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
    {
        private readonly IMemberRepository memberRepository;

        public CreateMemberCommandHandler(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public async Task<Unit> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = Member.Create(request.MemberId, request.TenantId, request.EMailId, request.FirstName, request.LastName);

            await memberRepository.AddAsync(member);

            return Unit.Value;
        }
    }
}