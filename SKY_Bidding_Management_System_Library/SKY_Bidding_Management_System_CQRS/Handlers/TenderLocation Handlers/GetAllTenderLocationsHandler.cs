using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers
{

    public record GetAllTenderLocationsHandler(AppDbContext Db) : IRequestHandler<GetAllTenderLocationsQuery, List<TenderLocationDto>>
    {
        public async Task<List<TenderLocationDto>> Handle(GetAllTenderLocationsQuery request, CancellationToken cancellationToken)
        {
            var tenderLocations = await Db.TenderLocations
                .Select(tl => new TenderLocationDto
                {
                    TenderLocationId = tl.TenderLocationId,
                    TenderLocationName = tl.TenderLocationName
                })
                .ToListAsync(cancellationToken);

            return tenderLocations;
        }
    }
     
}
