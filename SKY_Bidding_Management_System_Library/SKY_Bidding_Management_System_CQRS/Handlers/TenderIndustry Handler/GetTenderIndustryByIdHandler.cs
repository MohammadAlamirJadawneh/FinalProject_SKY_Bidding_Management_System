using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderIndustry_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderIndustry_Handler
{
    public record GetTenderIndustryByIdHandler(AppDbContext Db) : IRequestHandler<GetTenderIndustryByIdQuery, TenderIndustryDto>
    {
        public async Task<TenderIndustryDto> Handle(GetTenderIndustryByIdQuery request, CancellationToken cancellationToken)
        {
            var tenderIndustry = await Db.TenderIndustries
                .Where(e => e.TenderIndustryId == request.tenderIndustryId)
                .Select(e => new TenderIndustryDto
                {
                    TenderIndustryId = e.TenderIndustryId,
                    TenderIndustryName = e.TenderIndustryName
                })
                .FirstOrDefaultAsync(cancellationToken);

            return tenderIndustry;
        }
    }
     
}