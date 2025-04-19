using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderAward_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderAwardHandlers
{
    public record GetTenderAwardByIdHandler(AppDbContext Db) : IRequestHandler<GetTenderAwardByIdQuery, TenderAwardDto>
    {
        public async Task<TenderAwardDto> Handle(GetTenderAwardByIdQuery request, CancellationToken cancellationToken)
        {
            var tenderAward = await Db.TenderAwards
                .Where(e => e.TenderAwardId == request.TenderAwardId)
                .Select(e => new TenderAwardDto
                {
                    TenderAwardId = e.TenderAwardId,
                    TenderId = e.TenderId,
                    BidId = e.BidId,
                    AwardDate = e.AwardDate,
                    AwardStatus = e.AwardStatus
                })
                .FirstOrDefaultAsync(cancellationToken);

            return tenderAward;
        }
    }
     
}
