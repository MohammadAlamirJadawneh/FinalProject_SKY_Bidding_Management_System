using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands
{

    public record DeleteTenderCategoryCommand(int TenderCategoryId) : IRequest<bool>;

}
