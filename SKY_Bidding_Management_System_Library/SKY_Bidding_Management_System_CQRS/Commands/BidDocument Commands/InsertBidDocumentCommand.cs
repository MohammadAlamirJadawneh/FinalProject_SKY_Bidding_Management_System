using MediatR;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands
{


    public record InsertBidDocumentCommand(string FileName, string ContentType, byte[] Data, int BidId) : IRequest<BidDocumentDto>;

    public record AddBidDocumentCommand(int BidId, IFormFile File) : IRequest<bool>;


}
