using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderIndustry_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderIndustry_Handler
{
    public record GetAllTenderIndustrysHandler(AppDbContext Db) : IRequestHandler<GetAllTenderIndustryQuery, List<TenderIndustryDto>>
    {
        public async Task<List<TenderIndustryDto>> Handle(GetAllTenderIndustryQuery request, CancellationToken cancellationToken)
        {
            var tenderIndustrys = await Db.TenderIndustries
                .Select(tl => new TenderIndustryDto
                {
                    TenderIndustryId = tl.TenderIndustryId,
                    TenderIndustryName = tl.TenderIndustryName
                })
                .ToListAsync(cancellationToken);

            return tenderIndustrys;
        }
    }
     
}
