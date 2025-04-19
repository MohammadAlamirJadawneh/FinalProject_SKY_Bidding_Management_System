using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;

namespace SKY_Bidding_Management_System_Library.Service.BidService
{
    public interface IBidService
    {


        Task<FileContentResult> DownloadBidDocumentsAsZipAsync(int bidId);
        Task<BidDto> InsertBidAsync(InsertBidCommand command);
        Task<BidDto> UpdateBidAsync(UpdateBidCommand command);
        Task<bool> DeleteBidAsync(DeleteBidCommand command);
        Task<BidDto> GetBidByIdAsync(GetBidByIdQuery query);
        Task<List<BidDto>> GetAllBidsAsync(GetAllBidsQuery query);
        Task<byte[]> GenerateBidSubmissionDocumentAsync(int bidId);
        Task<byte[]> GenerateBidProposalDocumentAsync(int bidId);
        Task<string> GenerateSupportingDocumentsText(int bidId);
        Task<string> GenerateDeclarationText(string companyName, string authorizedSignatory, DateTime submissionDate);
    }

}
