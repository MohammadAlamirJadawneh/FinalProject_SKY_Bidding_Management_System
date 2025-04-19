using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands
{

    public record InsertTenderCategoryCommand(InsertTenderCategoryDto tenderCategory) : IRequest<TenderCategoryDto>;

}
