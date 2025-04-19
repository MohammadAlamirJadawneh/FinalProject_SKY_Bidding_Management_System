using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.SupportingDocumentsText;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.SupportingDocumentsTextCommands
{
    public record GenerateSupportingDocumentsTextCommand(
    int BidId,   List<SupportingDocumentDto> SupportingDocuments ) : IRequest<string>;
     

     

}
