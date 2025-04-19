using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderIndustry_Queries
{

    public record GetTenderIndustryByIdQuery(int tenderIndustryId) : IRequest<TenderIndustryDto>;

}
