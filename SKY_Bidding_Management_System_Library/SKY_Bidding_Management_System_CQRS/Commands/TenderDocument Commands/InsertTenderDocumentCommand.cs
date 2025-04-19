using MediatR;
using Microsoft.AspNetCore.Http;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands
{
 
    public record InsertTenderDocumentCommand(
        string FileName, string ContentType,
        byte[] Data,  int TenderId
    ) : IRequest<TenderDocumentDto>;
    public record AddTenderDocumentCommand(int TenderId, IFormFile File) : IRequest<bool>;
}
