using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands
{
    public record UpdateTenderCommand(
    int TenderId,  string TenderTitle,
    string TenderDescription, decimal TenderBudget, DateTime TenderIssueDate,
    DateTime TenderClosingDate, string Email, string EligibilityCriteria,
    int CategoryId, int IndustryId, int TenderTypeId, int LocationId
     ) : IRequest<TenderDto>;

}
