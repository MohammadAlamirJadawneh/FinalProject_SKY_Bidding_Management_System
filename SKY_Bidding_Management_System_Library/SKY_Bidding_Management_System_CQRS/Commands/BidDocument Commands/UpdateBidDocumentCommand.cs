using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands
{
    public record UpdateBidDocumentCommand(int BidDocumentId, string FileName, string ContentType, byte[] Data) : IRequest<BidDocumentDto>;





}
 
