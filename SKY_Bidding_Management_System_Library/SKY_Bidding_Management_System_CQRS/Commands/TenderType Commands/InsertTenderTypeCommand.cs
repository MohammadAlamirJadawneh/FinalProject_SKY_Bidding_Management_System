using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands
{

    public record InsertTenderTypeCommand(InsertTenderTypeDto tenderType) : IRequest<TenderTypeDto>;

}
