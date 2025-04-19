using MediatR;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Data.DTOs.FinancialProposalItem;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands
{

     public record InsertBidCommand(int TenderId , DateTime SubmissionDate, IEnumerable<IFormFile> Files, string? TechnicalSummary, List<FinancialProposalItemDto>? FinancialProposalItems, string? CompanyName, string? RegistrationNumber, string? Address, string? Email, string? Phone) : IRequest<BidDto>;

}
