using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands
{
    public record UpdateTenderDocumentCommand(
      int TenderDocumentId, string FileName,
      string ContentType, byte[] Data
) : IRequest<TenderDocumentDto>;
}
