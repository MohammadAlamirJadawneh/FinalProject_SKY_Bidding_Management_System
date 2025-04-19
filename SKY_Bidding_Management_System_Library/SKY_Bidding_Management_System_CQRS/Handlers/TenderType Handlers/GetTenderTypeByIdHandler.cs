using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderType_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderType_Handlers
{
    public record GetTenderTypeByIdHandler(AppDbContext Db) : IRequestHandler<GetTenderTypeByIdQuery, TenderTypeDto>
    {
        public async Task<TenderTypeDto> Handle(GetTenderTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var tenderType = await Db.TenderTypes
                .Where(e => e.TenderTypeId == request.tenderTypeId)
                .Select(e => new TenderTypeDto
                {
                    TenderTypeId = e.TenderTypeId,
                    TenderTypeName = e.TenderTypeName
                })
                .FirstOrDefaultAsync(cancellationToken);

            return tenderType;
        }
    }


}
