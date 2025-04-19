using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.SubmissionGuidelinesCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SubmissionGuidelinesQueries;

namespace SKY_Bidding_Management_System_Library.Service.SubmissionGuidelineService
{
    public class SubmissionGuidelineService : ISubmissionGuidelineService
    {
        private readonly IMediator _mediator;

        public SubmissionGuidelineService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> AddSubmissionGuidelinesAsync(List<SubmissionGuidelineDto> guidelines)
        {
            var result = await _mediator.Send(new InsertSubmissionGuidelinesCommand(guidelines));
            if (result == null)
            {
                return false;
            }

            return result;
        }

        public async Task<SubmissionGuidelineDto> GetSubmissionGuidelinesByTenderIdAsync(int tenderId)
        { 
            var submissionGuidelines = await _mediator.Send(new GetSubmissionGuidelineByTenderIdQuery(tenderId));
            if (submissionGuidelines == null)
            {
                return null;
            }
            return submissionGuidelines;
        }
    }

}
