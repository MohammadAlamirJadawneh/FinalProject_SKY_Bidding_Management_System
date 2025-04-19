using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderType_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderType_Handlers
{
    public record GetAllTenderTypesHandler(AppDbContext Db) : IRequestHandler<GetAllTenderTypesQuery, List<TenderTypeDto>>
    {
        public async Task<List<TenderTypeDto>> Handle(GetAllTenderTypesQuery request, CancellationToken cancellationToken)
        {
            var tenderTypes = await Db.TenderTypes
                .Select(tl => new TenderTypeDto
                {
                    TenderTypeId = tl.TenderTypeId,
                    TenderTypeName = tl.TenderTypeName
                })
                .ToListAsync(cancellationToken);

            return tenderTypes;
        }
    }


}
