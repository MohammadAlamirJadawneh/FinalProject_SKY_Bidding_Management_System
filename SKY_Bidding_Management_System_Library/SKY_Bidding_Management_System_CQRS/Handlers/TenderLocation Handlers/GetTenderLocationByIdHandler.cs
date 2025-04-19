using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers
{
    public record GetTenderLocationByIdHandler(AppDbContext Db) : IRequestHandler<GetTenderLocationByIdQuery, TenderLocationDto>
    {
        public async Task<TenderLocationDto> Handle(GetTenderLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var tenderLocation = await Db.TenderLocations
                .Where(e => e.TenderLocationId == request.tenderLocationId)
                .Select(e => new TenderLocationDto
                {
                    TenderLocationId = e.TenderLocationId,
                    TenderLocationName = e.TenderLocationName
                })
                .FirstOrDefaultAsync(cancellationToken);

            return tenderLocation;
        }
    }
 
}
