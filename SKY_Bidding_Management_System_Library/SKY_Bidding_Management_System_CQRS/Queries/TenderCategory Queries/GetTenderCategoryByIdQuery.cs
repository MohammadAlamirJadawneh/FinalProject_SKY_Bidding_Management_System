using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderCategory_Queries
{

    public record GetTenderCategoryByIdQuery(int tenderCategoryId) : IRequest<TenderCategoryDto>;

}
