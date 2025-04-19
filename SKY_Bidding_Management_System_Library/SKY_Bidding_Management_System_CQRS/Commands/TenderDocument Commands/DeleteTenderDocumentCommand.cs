using MediatR;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands
{
    public record DeleteTenderDocumentCommand(int TenderDocumentId) : IRequest<bool>;

}
