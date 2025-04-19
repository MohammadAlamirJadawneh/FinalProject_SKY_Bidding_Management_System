using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands
{


    public record DeleteTenderTypeCommand(int TenderTypeId) : IRequest<bool>;

}
