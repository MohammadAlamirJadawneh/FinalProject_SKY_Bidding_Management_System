using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands
{

    public record UpdateTenderIndustryCommand(int tenderIndustryId, string tenderIndustryName) : IRequest<TenderIndustryDto>;

}
