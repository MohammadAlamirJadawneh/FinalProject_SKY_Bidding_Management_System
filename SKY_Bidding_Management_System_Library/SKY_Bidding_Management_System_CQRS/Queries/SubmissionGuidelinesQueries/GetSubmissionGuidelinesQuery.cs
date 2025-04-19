using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SubmissionGuidelinesQueries
{
    public record GetSubmissionGuidelinesQuery(int TenderId) : IRequest<List<SubmissionGuidelineDto>>;

}
