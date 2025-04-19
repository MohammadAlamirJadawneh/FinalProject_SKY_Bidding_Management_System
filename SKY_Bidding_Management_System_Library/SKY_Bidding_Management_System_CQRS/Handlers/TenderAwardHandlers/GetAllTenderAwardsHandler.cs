using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderAward_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderAwardHandlers
{
    public record GetAllTenderAwardsHandler(AppDbContext Db) : IRequestHandler<GetAllTenderAwardsQuery, List<TenderAwardDto>>
    {
        public async Task<List<TenderAwardDto>> Handle(GetAllTenderAwardsQuery request, CancellationToken cancellationToken)
        {
            var tenderAwards = await Db.TenderAwards
                .Select(a => new TenderAwardDto
                {
                    TenderAwardId = a.TenderAwardId,
                    TenderId = a.TenderId,
                    BidId = a.BidId,
                    AwardDate = a.AwardDate,
                    AwardStatus = a.AwardStatus
                }).ToListAsync(cancellationToken);

            return tenderAwards;
        }
    }

    
}
